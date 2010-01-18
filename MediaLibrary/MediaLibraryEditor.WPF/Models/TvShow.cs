using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

using MediaLibraryEditor.WPF.Commands;
using MediaLibraryEditor.WPF.Models;
using System.Collections.ObjectModel;

namespace MediaLibraryEditor.WPF.ViewModels.TvShow
{
    class TvShow : BusinessObjectBase
    {

        private MediaCatalogueEntities _ctx;
        private Media_Item _tvShow;


        #region --  Constructor  --

        /// <summary>
        /// Creates a new instance of the TvShowViewModel, loading the Media_Item entity
        /// with the specified id.
        /// </summary>
        /// <param name="id"></param>
        public TvShow(Guid id)
        {
            _ctx = new MediaCatalogueEntities();

            _tvShow = (from mi in _ctx.Media_Item
                                  .Include("TV_SeriesMedia")
                       where mi.id == id
                       select mi).FirstOrDefault();

            if (_tvShow.TV_SeriesMedia != null)
            {
                var seriesMediaId = _tvShow.TV_SeriesMedia.FirstOrDefault().id;

                SeriesID = (from seriesMedia in _ctx.TV_SeriesMedia
                                           .Include("TV_Series")
                            where seriesMedia.id == seriesMediaId
                            select seriesMedia.TV_Series.id).FirstOrDefault();
            }

            ID = id;
            Title = _tvShow.Title;
            Description = _tvShow.Description;
            IsDirty = false;
        }

        private TvShow()
        {
            ID = Guid.NewGuid();
            Title = "New TV Show";
            IsNew = true;
            IsDirty = false;
        }

        #endregion

        #region --  ICommand  --

        private DelegateCommand _editSegmentsCommand;

        public ICommand EditSegmentsCommand
        {
            get
            {
                if (_editSegmentsCommand == null)
                {
                    _editSegmentsCommand = new DelegateCommand(EditSegments, CanEditSegments);
                }
                return _editSegmentsCommand;
            }
        }


        private bool CanEditSegments()
        {
            return !IsNew;
        }

        private void EditSegments()
        {
            var tvDetails = new TvShowDetailsViewModel(_tvShow.id);
            var popupWindow = new Views.PopupWindow
                                  {
                                      Title = "Edit Segments",
                                      DataContext = tvDetails
                                  };
            popupWindow.Show();
        }

        #endregion

        #region --  Properties  --

        private Guid _id;

        public Guid ID
        {
            get { return _id; }
            set
            {
                if (value == _id) { return; }
                _id = value;
                OnPropertyChanged("ID");
            }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                if (value != _title)
                {
                    _title = value;
                    OnPropertyChanged("Title");
                }
            }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set
            {
                if (value != _description)
                {
                    _description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        private Guid _seriesID;

        public Guid SeriesID
        {
            get { return _seriesID; }
            set
            {
                if (value.Equals(_seriesID))
                {
                    return;
                }
                _seriesID = value;
                OnPropertyChanged("SeriesID");
            }
        }


        // ToDo: Implement a generic 'Lazy<>' class for this kind of thing...
        private bool _hasSegments;
        private bool _hasSegmentsChecked;

        // ToDo: This is flawed anyway - check is only ever done once, but can easily add a segment after this has been checked.
        /// <summary>
        /// Identifies whether this TV Show has any attached segments.
        /// </summary>
        public bool HasSegments
        {
            get
            {
                if (!_hasSegmentsChecked)
                {
                    if (_ctx != null)
                    {
                        var segCount = (from seg in _ctx.Media_Segment
                                        where seg.Media_Item.id == ID
                                        select seg).Count();
                        _hasSegments = segCount > 0;
                    }
                    _hasSegmentsChecked = true;
                }
                return _hasSegments;
            }
        }

        #endregion

        #region --  Methods  --

        protected override CommandResult Update()
        {

            if (_ctx == null)
            {
                _ctx = new MediaCatalogueEntities();
            }

            if (_tvShow == null)
            {
                _tvShow = new Media_Item();
                _tvShow.id = ID;
                _ctx.AddToMedia_Item(_tvShow);
            }

            // Update the various Entity objects with changes made and save them.
            _tvShow.Title = Title;
            _tvShow.Description = Description;

            // Find/create a TV SeriesMedia link

            if (SeriesID != Guid.Empty)
            {
                if ((from seriesMedia in _ctx.TV_SeriesMedia
                                             .Include("TV_Series")
                                             .Include("Media_Item")
                     where seriesMedia.Media_Item.id == _tvShow.id &&
                           seriesMedia.TV_Series.id == SeriesID
                     select seriesMedia.id).Count() == 0)
                {
                    // No TV_SeriesMedia record exists yet - create one
                    var tvSeriesMedia = new TV_SeriesMedia
                    {
                        id = Guid.NewGuid(),
                        Media_Item = _tvShow,
                    };

                    tvSeriesMedia.TV_Series = (from series in _ctx.TV_Series
                                               where series.id == SeriesID
                                               select series).FirstOrDefault();
                }

            }

            try
            {
                _ctx.SaveChanges();
            }
            catch (Exception)
            {
                return CommandResult.Failed;
            }

            return CommandResult.Successful;

        }

        protected override bool CanDelete()
        {
            return base.CanDelete() && !HasSegments;
        }

        protected override CommandResult Delete()
        {
            // ToDo: Delete any TV_SeriesMedia records for this media

            if (_ctx == null) { return CommandResult.Failed; }

            var serMedias = from serMed in _ctx.TV_SeriesMedia
                            where serMed.Media_Item.id == ID
                            select serMed;

            foreach (var sm in serMedias)
            {
                _ctx.DeleteObject(sm);
            }

            try
            {
                _ctx.SaveChanges();
            }
            catch (Exception)
            {
                return CommandResult.Failed;
            }

            return CommandResult.Successful;

        }

        public static TvShow NewTvShow(Guid tvSeriesId)
        {
            var newShow = new TvShow { SeriesID = tvSeriesId };
            return newShow;
        }

        #endregion

    }
}

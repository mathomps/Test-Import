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
    class TvShowViewModel : ViewModelBase
    {

        private MediaCatalogueEntities _ctx;
        private Media_Item _tvShow;


        #region --  Constructor  --

        /// <summary>
        /// Creates a new instance of the TvShowViewModel, loading the Media_Item entity
        /// with the specified id.
        /// </summary>
        /// <param name="id"></param>
        public TvShowViewModel(Guid id)
        {
            _ctx = new MediaCatalogueEntities();

            _tvShow = (from mi in _ctx.Media_Item
                       where mi.id == id
                       select mi).FirstOrDefault();

            if (_tvShow == null)
            {
                _tvShow = new Media_Item
                              {
                                  id = Guid.NewGuid(),
                                  Title = "New TV Show",
                                  Media_Type = MediaCatalogueHelper.GetTvShowType(_ctx)
                              };
                _ctx.AddToMedia_Item(_tvShow);

            }

            Title = _tvShow.Title;
            Description = _tvShow.Description;

        }

        #endregion

        #region --  ICommand  --

        private DelegateCommand _saveCommand;

        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new DelegateCommand(SaveTvShow, CanSaveTvShow);
                }
                return _saveCommand;
            }
        }

        private bool CanSaveTvShow()
        {
            return true;
        }

        private void SaveTvShow()
        {
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

            _ctx.SaveChanges();

        }


        private DelegateCommand _editSegmentsCommand;

        public ICommand EditSegmentsCommand
        {
            get
            {
                if (_editSegmentsCommand == null)
                {
                    _editSegmentsCommand = new DelegateCommand(EditSegments);
                }
                return _editSegmentsCommand;
            }
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

        #endregion

    }
}

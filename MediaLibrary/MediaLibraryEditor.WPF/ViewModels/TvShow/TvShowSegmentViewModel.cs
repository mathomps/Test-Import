using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MediaLibraryEditor.WPF.Models;
using MediaLibraryEditor.WPF.Commands;
using System.Windows.Input;

namespace MediaLibraryEditor.WPF.ViewModels.TvShow
{
    public class TvShowSegmentViewModel : ViewModelBase
    {

        private MediaCatalogueEntities _ctx;

        #region --  Constructor  --

        public TvShowSegmentViewModel(Guid segmentId)
        {

            _ctx = new MediaCatalogueEntities();

            var segment = (from seg in _ctx.Media_Segment
                                       .Include("Media_Item")
                                       .Include("TV_Presenter")
                                       .Include("TV_SeriesCategory")

                           where seg.id == segmentId
                           select seg).FirstOrDefault();

            this.ID = segmentId;

            if (segment != null)
            {

                var seriesId = (from sm in _ctx.TV_SeriesMedia
                                where sm.Media_Item.id == segment.Media_Item.id
                                select sm.TV_Series.id).FirstOrDefault();

                Presenters = MediaCatalogueHelper.GetTvSeriesPresenters(seriesId, _ctx);
                Categories = MediaCatalogueHelper.GetTvSeriesCategories(seriesId, _ctx);

                this.Title = segment.Title;
                this.Description = segment.Description;
                this.StartOffset = segment.SectionOffset;
                this.SectionLength = segment.SectionLength;

                this.Presenter = segment.TV_Presenter;
                this.Category = segment.TV_SeriesCategory;
            }
        }

        #endregion


        #region --  ICommand  --

        private DelegateCommand _updateCommand;

        public ICommand UpdateCommand
        {
            get
            {
                if (_updateCommand == null)
                {
                    _updateCommand = new DelegateCommand(Update, CanUpdate);
                }
                return _updateCommand;
            }
        }

        private bool CanUpdate()
        {
            return true;
        }

        private void Update()
        {
            var ctx = new MediaCatalogueEntities();
            var seg = (from segment in ctx.Media_Segment
                       where segment.id == ID
                       select segment).FirstOrDefault();

            if (seg == null)
            {
                // Add as a new segment
                seg = new Media_Segment
                          {
                              id = ID,
                              Title = this.Title,
                              Description = this.Description,
                              SectionOffset = this.StartOffset,
                              SectionLength = this.SectionLength,
                          };

                seg.Media_Item = (from media in ctx.Media_Item
                                  where media.id == ParentId
                                  select media).FirstOrDefault();

                ctx.AddToMedia_Segment(seg);
            }
            else
            {
                seg.Title = this.Title;
                seg.Description = this.Description;
                seg.SectionOffset = this.StartOffset;
                seg.SectionLength = this.SectionLength;
            }


            // Update Presenter
            if (Presenter == null)
            {
                seg.TV_Presenter = null;
            }
            else
            {
                seg.TV_Presenter = (from pres in ctx.TV_Presenter
                                    where pres.id == Presenter.id
                                    select pres).FirstOrDefault();
            }

            // Update SeriesCategory
            if (Category == null)
            {
                seg.TV_SeriesCategory = null;
            }
            else
            {
                seg.TV_SeriesCategory = (from cat in ctx.TV_SeriesCategory
                                         where cat.id == Category.id
                                         select cat).FirstOrDefault();
            }

            ctx.SaveChanges();

        }

        #endregion

        #region --  Properties  --

        private Guid _parentId;

        /// <summary>
        /// The GUID of the Parent Media_Item for this segment
        /// </summary>
        public Guid ParentId
        {
            get { return _parentId; }
            set
            {
                if (value == _parentId) { return; }
                _parentId = value;
                OnPropertyChanged("ParentId");
            }
        }

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
                if (value == _title) { return; }
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set
            {
                if (value == _description) { return; }
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        private int? _startOffset;

        public int? StartOffset
        {
            get { return _startOffset; }
            set
            {
                if (value == _startOffset) { return; }
                _startOffset = value;
                OnPropertyChanged("StartOffset");
            }
        }

        private int? _sectionLength;

        public int? SectionLength
        {
            get { return _sectionLength; }
            set
            {
                if (value == _sectionLength) { return; }
                _sectionLength = value;
                OnPropertyChanged("SectionLength");
            }
        }


        private List<TV_SeriesCategory> _categories;

        public List<TV_SeriesCategory> Categories
        {
            get { return _categories; }
            set
            {
                if (value == _categories) { return; }
                _categories = value;
                OnPropertyChanged("Categories");
            }
        }

        private List<TV_Presenter> _presenters;

        public List<TV_Presenter> Presenters
        {
            get { return _presenters; }
            set
            {
                if (value == _presenters) { return; }
                _presenters = value;
                OnPropertyChanged("Presenters");
            }
        }



        private TV_SeriesCategory _category;

        public TV_SeriesCategory Category
        {
            get { return _category; }
            set
            {
                if (value == _category) { return; }
                _category = value;
                OnPropertyChanged("SelectedCategory");
            }
        }



        private TV_Presenter _presenter;

        public TV_Presenter Presenter
        {
            get { return _presenter; }
            set
            {
                if (value == _presenter) { return; }
                _presenter = value;
                OnPropertyChanged("Presenter");
            }
        }

        #endregion

        #region --  Methods  --

        public static TvShowSegmentViewModel NewSegment(Guid tvShowId)
        {
            var seg = new TvShowSegmentViewModel(Guid.NewGuid());
            seg.ParentId = tvShowId;
            seg.Title = "new segment";
            seg.Description = "enter a description for this segment.";

            var tvSeriesId = (from ser in seg._ctx.TV_SeriesMedia
                                          .Include("TV_Series")
                              where ser.Media_Item.id == tvShowId
                              select ser.TV_Series.id).FirstOrDefault();

            seg.Presenters = MediaCatalogueHelper.GetTvSeriesPresenters(tvSeriesId, seg._ctx);
            seg.Categories = MediaCatalogueHelper.GetTvSeriesCategories(tvSeriesId, seg._ctx);

            return seg;
        }

        #endregion

    }
}

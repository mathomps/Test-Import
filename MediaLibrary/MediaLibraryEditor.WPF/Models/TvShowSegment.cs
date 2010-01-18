using System;
using System.Collections.Generic;
using System.Linq;

namespace MediaLibraryEditor.WPF.Models
{
    public class TvShowSegment : BusinessObjectBase
    {

        private MediaCatalogueEntities _ctx;
        private Media_Segment _segment;

        #region --  Constructor  --

        public TvShowSegment(Guid segmentId)
        {

            _ctx = new MediaCatalogueEntities();

            _segment = (from seg in _ctx.Media_Segment
                                       .Include("Media_Item")
                                       .Include("TV_Presenter")
                                       .Include("TV_SeriesCategory")
                        where seg.id == segmentId
                        select seg).FirstOrDefault();

            ID = segmentId;

            if (_segment != null)
            {
                var seriesId = (from sm in _ctx.TV_SeriesMedia
                                where sm.Media_Item.id == _segment.Media_Item.id
                                select sm.TV_Series.id).FirstOrDefault();

                Presenters = MediaCatalogueHelper.GetTvSeriesPresenters(seriesId, _ctx);
                Categories = MediaCatalogueHelper.GetTvSeriesCategories(seriesId, _ctx);

                Title = _segment.Title;
                Description = _segment.Description;
                StartOffset = _segment.SectionOffset;
                SectionLength = _segment.SectionLength;

                if (_segment.TV_Presenter != null)
                {
                    Presenter = (from pres in Presenters
                                 where pres.ID == _segment.TV_Presenter.id
                                 select pres).FirstOrDefault();
                }

                if (_segment.TV_SeriesCategory != null)
                {
                    Category = (from cat in Categories
                                where cat.ID == _segment.TV_SeriesCategory.id
                                select cat).FirstOrDefault();
                }

            }

            IsDirty = false;

        }


        private TvShowSegment()
        {

            IsNew = true;
            IsDirty = false;
        }

        #endregion

        #region --  Properties  --

        private Guid _parentId;

        /// <summary>
        /// The GUID of the Parent Media_Item for this segment
        /// </summary>
        public Guid ParentID
        {
            get { return _parentId; }
            set
            {
                if (value == _parentId) { return; }
                _parentId = value;
                OnPropertyChanged("ParentID");
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


        private List<TvSeriesCategory> _categories;

        public List<TvSeriesCategory> Categories
        {
            get { return _categories; }
            set
            {
                if (value == _categories) { return; }
                _categories = value;
                OnPropertyChanged("Categories");
            }
        }

        private List<TvSeriesPresenter> _presenters;

        public List<TvSeriesPresenter> Presenters
        {
            get { return _presenters; }
            set
            {
                if (value == _presenters) { return; }
                _presenters = value;
                OnPropertyChanged("Presenters");
            }
        }



        private TvSeriesCategory _category;

        public TvSeriesCategory Category
        {
            get { return _category; }
            set
            {
                if (value == _category) { return; }
                _category = value;
                OnPropertyChanged("SelectedCategory");
            }
        }



        private TvSeriesPresenter _presenter;

        public TvSeriesPresenter Presenter
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

        public static TvShowSegment NewSegment(Guid tvShowId)
        {
            var ctx = new MediaCatalogueEntities();
            var seg = new TvShowSegment
                          {
                              ID = Guid.NewGuid(),
                              ParentID = tvShowId,
                              Title = "new segment",
                              Description = "enter a description for this segment."
                          };

            var tvSeriesId = (from ser in ctx.TV_SeriesMedia
                                          .Include("TV_Series")
                              where ser.Media_Item.id == tvShowId
                              select ser.TV_Series.id).FirstOrDefault();

            seg.Presenters = MediaCatalogueHelper.GetTvSeriesPresenters(tvSeriesId, ctx);
            seg.Categories = MediaCatalogueHelper.GetTvSeriesCategories(tvSeriesId, ctx);

            return seg;
        }

        protected override CommandResult Update()
        {

            if (_ctx == null)
            {
                _ctx = new MediaCatalogueEntities();
            }

            if (IsNew)
            {
                _segment = new Media_Segment { id = this.ID };
                _segment.Media_Item = (from media in _ctx.Media_Item
                                       where media.id == ParentID
                                       select media).FirstOrDefault();

                _ctx.AddToMedia_Segment(_segment);

            }

            _segment.Title = this.Title;
            _segment.Description = this.Description;
            _segment.SectionOffset = this.StartOffset;
            _segment.SectionLength = this.SectionLength;


            //var seg = (from segment in _ctx.Media_Segment
            //           where segment.id == ID
            //           select segment).FirstOrDefault();

            //if (seg == null)
            //{
            //    // Add as a new segment
            //    seg = new Media_Segment
            //    {
            //        id = ID,
            //        Title = this.Title,
            //        Description = this.Description,
            //        SectionOffset = this.StartOffset,
            //        SectionLength = this.SectionLength,
            //    };

            //    seg.Media_Item = (from media in _ctx.Media_Item
            //                      where media.id == ParentID
            //                      select media).FirstOrDefault();

            //    ctx.AddToMedia_Segment(seg);
            //}
            //else
            //{
            //    seg.Title = this.Title;
            //    seg.Description = this.Description;
            //    seg.SectionOffset = this.StartOffset;
            //    seg.SectionLength = this.SectionLength;
            //}


            // Update Presenter
            if (Presenter == null)
            {
                _segment.TV_Presenter = null;
            }
            else
            {
                _segment.TV_Presenter = (from pres in _ctx.TV_Presenter
                                         where pres.id == Presenter.ID
                                         select pres).FirstOrDefault();
            }

            // Update SeriesCategory
            if (Category == null)
            {
                _segment.TV_SeriesCategory = null;
            }
            else
            {
                _segment.TV_SeriesCategory = (from cat in _ctx.TV_SeriesCategory
                                              where cat.id == Category.ID
                                              select cat).FirstOrDefault();
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


        protected override CommandResult Delete()
        {


            // Delete from the DB
            var seg = (from segs in _ctx.Media_Segment
                       where segs.id == ID
                       select segs).FirstOrDefault();

            if (_segment == null) { return CommandResult.Failed; }

            try
            {
                _ctx.DeleteObject(seg);
                _ctx.SaveChanges();
            }
            catch (Exception)
            {
                return CommandResult.Failed;
            }

            return CommandResult.Successful;

        }

        #endregion



    }
}

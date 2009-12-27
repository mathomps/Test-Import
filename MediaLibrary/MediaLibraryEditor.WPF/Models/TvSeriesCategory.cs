using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaLibraryEditor.WPF.Models
{


    public class TvSeriesCategory : BusinessObjectBase
    {

        private MediaCatalogueEntities _ctx;
        private TV_SeriesCategory _category;

        #region --  Constructor  --

        public TvSeriesCategory(Guid categoryId)
        {
            _ctx = new MediaCatalogueEntities();

            _category = (from cat in _ctx.TV_SeriesCategory
                         where cat.id == categoryId
                         select cat).FirstOrDefault();
            ID = _category.id;
            Title = _category.Title;
            Description = _category.Description;
            IsDirty = false;
        }

        /// <summary>
        /// Constructor used by shared method to create a new empty TVSeriesCategory.
        /// </summary>
        private TvSeriesCategory()
        {
            ID = Guid.NewGuid();
            Title = "New category";
            Description = "Enter a description for this category";
            IsNew = true;
            IsDirty = false;
        }

        #endregion

        #region --  Properties  --

        private Guid _id;

        public Guid ID
        {
            get { return _id; }
            private set
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


        private Guid _seriesId;

        public Guid SeriesID
        {
            get { return _seriesId; }
            set
            {
                if (value == _seriesId) { return; }
                _seriesId = value;
                OnPropertyChanged("SeriesID");
            }
        }

        #endregion

        #region --  Methods  --

        public static TvSeriesCategory NewCategory(Guid tvSeriesId)
        {
            var newCategory = new TvSeriesCategory
            {
                SeriesID = tvSeriesId,
                IsDirty = false
            };
            return newCategory;
        }

        protected override CommandResult Update()
        {

            if (_ctx == null)
            {
                _ctx = new MediaCatalogueEntities();
            }

            if (IsNew)
            {
                var tvSeries = (from series in _ctx.TV_Series
                                where series.id == SeriesID
                                select series).FirstOrDefault();

                // Note: Because we are attaching a Series to the SeriesCategory, the SeriesCategory
                // is automatically associated with the DataContext we are using - no need to manually add it.
                _category = new TV_SeriesCategory
                {
                    id = this.ID,
                    TV_Series = tvSeries
                };
            }

            _category.Title = Title;
            _category.Description = Description;

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

            if (_ctx == null || _category == null) { return CommandResult.Failed; }

            try
            {
                _ctx.DeleteObject(_category);
                _ctx.SaveChanges();
            }
            catch (Exception)
            {
                return CommandResult.Failed;
            }

            return CommandResult.Successful;

        }


        public override string ToString()
        {
            return Title;
        }

        #endregion

    }


}

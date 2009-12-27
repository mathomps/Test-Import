using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaLibraryEditor.WPF.Models
{

    public class TvSeriesPresenter : BusinessObjectBase
    {

        private MediaCatalogueEntities _ctx;
        private TV_Presenter _presenter;

        #region --  Constructor  --

        public TvSeriesPresenter(Guid presenterId)
        {
            _ctx = new MediaCatalogueEntities();

            _presenter = (from presenter in _ctx.TV_Presenter
                          where presenter.id == presenterId
                          select presenter).FirstOrDefault();

            ID = _presenter.id;
            Name = _presenter.Name;
            IsDirty = false;
        }

        private TvSeriesPresenter()
        {
            ID = Guid.NewGuid();
            Name = "New Presenter";
            IsNew = true;
            IsDirty = false;
        }

        #endregion

        #region --  Properties  --

        private Guid _seriesId;

        public Guid SeriesId
        {
            get { return _seriesId; }
            set
            {
                if (value == _seriesId) { return; }
                _seriesId = value;
                OnPropertyChanged("SeriesId");
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

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) { return; }
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        #endregion

        #region --  Methods  --

        public static TvSeriesPresenter NewPresenter(Guid tvSeriesId)
        {
            var newPresenter = new TvSeriesPresenter
            {
                SeriesId = tvSeriesId,
                IsDirty = false
            };
            return newPresenter;
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
                                where series.id == SeriesId
                                select series).FirstOrDefault();

                _presenter = new TV_Presenter
                {
                    id = this.ID,
                    TV_Series = tvSeries
                };

            }

            _presenter.Name = Name;

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
            if (_ctx == null || _presenter == null) { return CommandResult.Failed; }

            try
            {
                _ctx.DeleteObject(_presenter);
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
            return Name;
        }

        #endregion

    }

}

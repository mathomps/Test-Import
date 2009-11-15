using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

using MediaLibraryEditor.WPF.Commands;
using MediaLibraryEditor.WPF.Models;


namespace MediaLibraryEditor.WPF.ViewModels.TvShow
{
    class TvSeriesViewModel : ViewModelBase
    {
        private TV_Series _series;
        private MediaCatalogueEntities _ctx;
        private string _description;
        private Guid _id;

        #region --  Constructor  --

        public TvSeriesViewModel(TV_Series series)
        {
            _ctx = new MediaCatalogueEntities();


            if (series != null)
            {
                _series = (from s in _ctx.TV_Series
                           where s.id == series.id
                           select s).FirstOrDefault();
            }

            if (_series == null)
            {
                _series = new TV_Series
                              {
                                  id = Guid.NewGuid(),
                                  Description = "New Series"
                              };
                _ctx.AddToTV_Series(_series);
            }

            Description = _series.Description;
            ID = _series.id;
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
                    _saveCommand = new DelegateCommand(Save);
                }
                return _saveCommand;
            }
        }

        private void Save()
        {
            _series.Description = Description;
            _ctx.SaveChanges();
        }

        #endregion

        #region --  Properties  --

        public Guid ID
        {
            get { return _id; }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    OnPropertyChanged("ID");
                }
            }
        }

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

        #endregion

    }
}

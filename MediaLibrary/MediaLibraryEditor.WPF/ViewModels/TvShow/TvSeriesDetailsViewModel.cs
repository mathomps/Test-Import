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
    class TvSeriesDetailsViewModel : ViewModelBase
    {
        private TV_Series _series;
        private MediaCatalogueEntities _ctx;
        
        

        


        #region --  Constructor  --

        public TvSeriesDetailsViewModel(TV_Series series)
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

        private Guid _id;

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

        private bool _isSelected;

        /// <summary>
        /// Indicates if this series is currently selected in the ListView
        /// </summary>
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value != _isSelected)
                {
                    _isSelected = value;
                    OnPropertyChanged("IsSelected");
                }
            }
        }


        // --  Episodes  --
        
        private TvShowsViewModel _tvShows;

        public TvShowsViewModel Episodes
        {
            get
            {
                // Lazy Load the TV Shows ViewModel so we are not trying to load
                // them until absolutely required.
                if (_tvShows == null)
                {
                    _tvShows = new TvShowsViewModel(ID);
                }
                return _tvShows;
            }
        }

        #endregion

    }
}

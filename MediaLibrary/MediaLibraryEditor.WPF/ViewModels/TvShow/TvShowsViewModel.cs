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
    class TvShowsViewModel : OperationViewModel
    {
        MediaCatalogueEntities _ctx;


        #region --  Constructor  --

        public TvShowsViewModel()
        {
            // Get the list of TV shows
            _ctx = new MediaCatalogueEntities();

            var shows = from mediaItem in _ctx.Media_Item.Include("Tv_SeriesMedia")
                        where mediaItem.TV_SeriesMedia.Count > 0
                        select mediaItem;

            foreach (var show in shows)
            {
                TvShows.Add(new TvShowViewModel(show));
            }

        }

        #endregion

        #region --  ICommand  --

        private DelegateCommand _addCommand;

        public ICommand AddShowCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new DelegateCommand(AddShow, CanAddShow);
                }
                return _addCommand;
            }
        }

        private bool CanAddShow()
        {
            return true;
        }

        private void AddShow()
        {
        }

        #endregion

        #region --  Properties  --

        public override string Title
        {
            get
            {
                return "TV - Edit Shows";
            }
        }

        private TvShowViewModel _selectedShow;

        public TvShowViewModel SelectedShow
        {
            get { return _selectedShow; }
            set
            {
                if (value != _selectedShow)
                {
                    _selectedShow = value;
                    OnPropertyChanged("SelectedShow");
                }
            }
        }


        private ObservableCollection<TvShowViewModel> _tvShows = new ObservableCollection<TvShowViewModel>();

        public ObservableCollection<TvShowViewModel> TvShows
        {
            get { return _tvShows; }
            set
            {
                if (value != _tvShows)
                {
                    _tvShows = value;
                    OnPropertyChanged("TvShows");
                }
            }
        }


        #endregion

    }
}

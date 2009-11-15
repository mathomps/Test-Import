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
        private EditTvSeriesViewModel _allTvSeries;
        private TV_SeriesMedia _linkedTvSeries;

        #region --  Constructor  --

        public TvShowViewModel(Media_Item tvShow)
        {
            _ctx = new MediaCatalogueEntities();

            if (tvShow != null)
            {
                _tvShow = (from mi in _ctx.Media_Item
                           where mi.id == tvShow.id
                           select mi).FirstOrDefault();
            }

            if (_tvShow == null)
            {
                _tvShow = new Media_Item
                              {
                                  id = Guid.NewGuid(),
                                  Description = "New TV Show"
                              };
            }


            _allTvSeries = new EditTvSeriesViewModel();

            Title = _tvShow.Title;
            Description = _tvShow.Description;

            // ToDo: Find the TV Series relating to this Media_Item

            var serieslink = from sermed in _ctx.TV_SeriesMedia.Include("TV_Series")
                             where sermed.Media_Item.id == _tvShow.id
                             select sermed;

            _linkedTvSeries = serieslink.FirstOrDefault();

            SelectedSeries = (from s in AllTvSeries
                              where s.ID == _linkedTvSeries.TV_Series.id
                              select s).FirstOrDefault();


            //SelectedSeries = from series in AllTvSeries
            //                 where series.Description == _tvShow.


            // ToDo: Find the Segments relating to this show.

            // Get


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

        public ObservableCollection<TvSeriesViewModel> AllTvSeries
        {
            get { return _allTvSeries.TvSeries; }
        }

        private TvSeriesViewModel _selectedSeries;

        public TvSeriesViewModel SelectedSeries
        {
            get { return _selectedSeries; }
            set
            {
                if (value != _selectedSeries)
                {
                    _selectedSeries = value;
                    OnPropertyChanged("SelectedSeries");
                }
            }

        }

        #endregion


    }
}

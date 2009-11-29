using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MediaLibraryEditor.WPF.Models;
using System.Collections.ObjectModel;
using MediaLibraryEditor.WPF.Commands;
using System.Windows.Input;

namespace MediaLibraryEditor.WPF.ViewModels.TvShow
{
    class TvSeriesListViewModel : OperationViewModel
    {

        private MediaCatalogueEntities _ctx;
        private ObservableCollection<TvSeriesDetailsViewModel> _seriesCollection;
        private TvSeriesDetailsViewModel _selectedSeries;

        public TvSeriesListViewModel()
        {
            _ctx = new MediaCatalogueEntities();
            _seriesCollection = new ObservableCollection<TvSeriesDetailsViewModel>();

            var seriesColl = (from series in _ctx.TV_Series
                              orderby series.Description
                              select series);

            foreach (var series in seriesColl)
            {
                _seriesCollection.Add(new TvSeriesDetailsViewModel(series));
            }
            OnPropertyChanged("TvSeries");

        }


        #region --  ICommand  --

        private DelegateCommand _addSeriesCommand;

        public ICommand AddSeriesCommand
        {
            get
            {
                if (_addSeriesCommand == null)
                {
                    _addSeriesCommand = new DelegateCommand(AddSeries);
                }
                return _addSeriesCommand;
            }
        }

        private void AddSeries()
        {
            //var series = new TV_Series
            //                 {
            //                     id = Guid.NewGuid(),
            //                     Description = "New series"
            //                 };
            var seriesVM = new TvSeriesDetailsViewModel(null);
            _seriesCollection.Add(seriesVM);
            //_ctx.AddToTV_Series(series);
            SelectedSeries = seriesVM;

        }


        #endregion

        #region --  Properties  --

        public ObservableCollection<TvSeriesDetailsViewModel> TvSeries
        {
            get { return _seriesCollection; }
        }


        public TvSeriesDetailsViewModel SelectedSeries
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


        public override string Title
        {
            get
            {
                return "TV - Edit Series";
            }
        }

        #endregion
    }
}

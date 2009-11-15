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
    class EditTvSeriesViewModel : OperationViewModel
    {

        private MediaCatalogueEntities _ctx;
        private ObservableCollection<TvSeriesViewModel> _seriesCollection;
        private TvSeriesViewModel _selectedSeries;

        public EditTvSeriesViewModel()
        {
            _ctx = new MediaCatalogueEntities();
            _seriesCollection = new ObservableCollection<TvSeriesViewModel>();

            var seriesColl = (from series in _ctx.TV_Series
                              orderby series.Description
                              select series);

            foreach (var series in seriesColl)
            {
                _seriesCollection.Add(new TvSeriesViewModel(series));
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
            var seriesVM = new TvSeriesViewModel(null);
            _seriesCollection.Add(seriesVM);
            //_ctx.AddToTV_Series(series);
            SelectedSeries = seriesVM;

        }


        #endregion

        #region --  Properties  --

        public ObservableCollection<TvSeriesViewModel> TvSeries
        {
            get { return _seriesCollection; }
        }


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

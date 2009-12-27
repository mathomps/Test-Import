using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

using MediaLibraryEditor.WPF.Commands;
using MediaLibraryEditor.WPF.Models;


namespace MediaLibraryEditor.WPF.ViewModels.TvShow
{
    public class TvSeriesPresentersViewModel : ViewModelBase
    {
        private MediaCatalogueEntities _ctx;
        private Guid _tvSeriesId;

        #region --  Constructor  --

        public TvSeriesPresentersViewModel(Guid tvSeriesId)
        {
            _ctx = new MediaCatalogueEntities();

            var presenterIds = from pres in _ctx.TV_Presenter
                                          .Include("TV_Series")
                               where pres.TV_Series.id == tvSeriesId
                               orderby pres.Name
                               select pres.id;

            _tvSeriesId = tvSeriesId;

            Presenters = new ObservableCollection<TvSeriesPresenter>();

            foreach (var presenterId in presenterIds)
            {
                Presenters.Add(new TvSeriesPresenter(presenterId));
            }

        }

        #endregion

        #region --  ICommand  --

        private DelegateCommand _addPresenterCommand;

        public ICommand AddPresenterCommand
        {
            get
            {
                if (_addPresenterCommand == null)
                {
                    _addPresenterCommand = new DelegateCommand(AddPresenter, CanAddPresenter);
                }
                return _addPresenterCommand;
            }
        }

        private bool CanAddPresenter()
        {
            return true;
        }

        private void AddPresenter()
        {
            var newPresenter = TvSeriesPresenter.NewPresenter(_tvSeriesId);
            Presenters.Add(newPresenter);
            SelectedPresenter = newPresenter;
        }


        private DelegateCommand _deletePresenterCommand;

        public ICommand DeletePresenterCommand
        {
            get
            {
                if (_deletePresenterCommand == null)
                {
                    _deletePresenterCommand = new DelegateCommand(DeletePresenter, CanDeletePresenter);
                }
                return _deletePresenterCommand;
            }
        }

        private bool CanDeletePresenter()
        {
            return (SelectedPresenter != null) && (SelectedPresenter.DeleteCommand.CanExecute(null));
        }

        private void DeletePresenter()
        {
            SelectedPresenter.DeleteCommand.Execute(null);
            Presenters.Remove(SelectedPresenter);
            SelectedPresenter = null;
        }

        #endregion

        #region --  Properties  --

        private ObservableCollection<TvSeriesPresenter> _presenters;

        public ObservableCollection<TvSeriesPresenter> Presenters
        {
            get { return _presenters; }
            set
            {
                if (value == _presenters) { return; }
                _presenters = value;
                OnPropertyChanged("Presenters");
            }
        }

        private TvSeriesPresenter _selectedPresenter;

        public TvSeriesPresenter SelectedPresenter
        {
            get { return _selectedPresenter; }
            set
            {
                if (value == _selectedPresenter) { return; }
                _selectedPresenter = value;
                OnPropertyChanged("SelectedPresenter");
            }
        }

        #endregion

    }

}

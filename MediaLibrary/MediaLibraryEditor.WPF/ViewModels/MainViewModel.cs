using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;


using MediaLibraryEditor.WPF.Commands;
using MediaLibraryEditor.WPF.ViewModels;

namespace MediaLibraryEditor.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        private ObservableCollection<OperationViewModel> _operations;


        private ModuleSelectionViewModel _moduleSelection;

        #region --  Constructor  --

        public MainViewModel()
        {
            _moduleSelection = new ModuleSelectionViewModel();

            _operations = new ObservableCollection<OperationViewModel>();
            _operations.Add(new Music.MusicImportViewModel());

        }

        #endregion

        #region --  ICommand  --

        private DelegateCommand exitCommand;

        public ICommand ExitCommand
        {
            get
            {
                if (exitCommand == null)
                {
                    exitCommand = new DelegateCommand(Exit);
                }
                return exitCommand;
            }
        }

        #endregion

        #region --  Methods  --

        private void Exit()
        {
            Application.Current.Shutdown();
        }

        #endregion

        #region --  Properties  --

        public ModuleSelectionViewModel ModuleSelection
        {
            get { return _moduleSelection; }
        }

        public ObservableCollection<OperationViewModel> Pages
        {
            get { return _operations; }
        }

        #endregion
    }
}

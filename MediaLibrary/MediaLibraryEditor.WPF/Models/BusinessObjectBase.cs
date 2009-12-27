using System.Windows.Input;

using MediaLibraryEditor.WPF.Commands;
using MediaLibraryEditor.WPF.ViewModels;
using System.ComponentModel;

namespace MediaLibraryEditor.WPF.Models
{
    public abstract class BusinessObjectBase : INotifyPropertyChanged
    {


        #region --  Enums  --

        public enum CommandResult
        {
            Successful,
            Failed,
            NotImplemented
        }

        #endregion

        #region --  Properties  --

        private bool _isDirty;

        public bool IsDirty
        {
            get { return _isDirty; }
            set
            {
                if (value == _isDirty) { return; }
                _isDirty = value;
                OnPropertyChanged("IsDirty", false);
            }
        }
        
        private bool _isNew;

        public bool IsNew
        {
            get { return _isNew; }
            set
            {
                if (value == _isNew) { return; }
                _isNew = value;
                OnPropertyChanged("IsNew", false);
            }
        }

        private bool _isSelected;

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value == _isSelected) { return; }
                _isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }
        
        private bool _isDeleted;

        public bool IsDeleted
        {
            get { return _isDeleted; }
            set
            {
                if (value == _isDeleted) { return; }
                _isDeleted = value;
                OnPropertyChanged("IsDeleted");
            }
        }

        #endregion

        #region --  ICommand  --

        private DelegateCommand _updateCommand;

        public ICommand UpdateCommand
        {
            get
            {
                if (_updateCommand == null)
                {
                    _updateCommand = new DelegateCommand(InternalUpdate, CanUpdate);
                }
                return _updateCommand;
            }
        }

        protected virtual bool CanUpdate()
        {
            return IsDirty;
        }

        private void InternalUpdate()
        {
            if (Update() == CommandResult.Successful)
            {
                IsDirty = false;
                IsNew = false;
            }
        }


        /// <summary>
        /// Override this in a derived class to save any changes made to this object back to its underlying data store.
        /// </summary>
        protected abstract CommandResult Update();


        //private DelegateCommand _addCommand;

        //public ICommand AddCommand
        //{
        //    get
        //    {
        //        if (_addCommand == null)
        //        {
        //            _addCommand = new DelegateCommand(Add);
        //        }
        //        return _addCommand;
        //    }
        //}

        ///// <summary>
        ///// Override this in a derived class to add a new object and initialise its properties.
        ///// </summary>
        //protected abstract void Add();


        private DelegateCommand _deleteCommand;

        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new DelegateCommand(InternalDelete, CanDelete);
                }
                return _deleteCommand;
            }
        }

        protected virtual bool CanDelete()
        {
            return true;
        }


        private void InternalDelete()
        {
            if (Delete() == CommandResult.Successful)
            {
                IsDeleted = true;
                IsDirty = false;
            }
        }

        /// <summary>
        /// Override this in a derived class to delete the underlying object from its data source.
        /// </summary>
        protected abstract CommandResult Delete();

        #endregion

        #region --  Methods  --

        #endregion

        #region --  INotifyPropertyChanged  --

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(propertyName, true);
        }

        public void OnPropertyChanged(string propertyName, bool flagAsDirty)
        {
            if (flagAsDirty) { IsDirty = true; }

            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}

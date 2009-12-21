using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaLibraryEditor.WPF.ViewModels
{
    public class BusinessObjectBase : ViewModelBase
    {


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

        #endregion

        #region --  Methods  --

        new public void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(propertyName, true);
        }

        public void OnPropertyChanged(string propertyName, bool flagAsDirty)
        {
            if (flagAsDirty) { IsDirty = true; }
            base.OnPropertyChanged(propertyName);
        }

        #endregion

    }
}

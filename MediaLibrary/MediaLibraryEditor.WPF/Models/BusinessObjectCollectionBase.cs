using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace MediaLibraryEditor.WPF.Models
{
    public abstract class BusinessObjectCollectionBase
    {

        public void BusinessObjectBase()
        {
            Items.CollectionChanged += Items_CollectionChanged;

        }

        void Items_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }



        private BusinessObjectBase _selectedItem;

        public BusinessObjectBase SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (value == _selectedItem) { return; }
                if (_selectedItem != null) { _selectedItem.IsSelected = false; }
                _selectedItem = value;
                if (_selectedItem != null) { _selectedItem.IsSelected = true; }
                OnPropertyChanged("SelectedItem");
            }
        }

        private ObservableCollection<BusinessObjectBase> _items;

        public ObservableCollection<BusinessObjectBase> Items
        {
            get { return _items; }
            set
            {
                if (value == _items) { return; }
                _items = value;
                OnPropertyChanged("Items");
            }
        }

    }
}

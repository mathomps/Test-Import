using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MediaLibraryEditor.WPF.Commands;
using MediaLibraryEditor.WPF.Models.MusicVideo;

namespace MediaLibraryEditor.WPF.ViewModels.MusicVideo
{
    class MusicVideosViewModel : OperationViewModelBase
    {
        private readonly MusicVideoRepository _mvRepository;

        #region --  Constructor  --

        public MusicVideosViewModel()
        {
            _mvRepository = new MusicVideoRepository();

            // Setup Commands
            SearchCommand = new DelegateCommand(Search);
            AddMusicVideoCommand = new DelegateCommand(AddMusicVideo);

        }

        #endregion

        #region --  Properties  --

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                if (value == _searchText) return;
                _searchText = value;
                OnPropertyChanged("SearchText");

                // Auto-search when 3 or more characters have been entered
                if (value.Length > 2)
                {
                    Search();
                }
            }
        }

        private IEnumerable<MusicVideoItem> _items;
        public IEnumerable<MusicVideoItem> Items
        {
            get { return _items; }
            private set
            {
                if (value == _items) return;
                _items = value;
                OnPropertyChanged("Items");

                HasSearchResults = _items != null && _items.Count() != 0;
            }
        }

        private MusicVideoItem _selectedItem;
        public MusicVideoItem SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (value == _selectedItem) return;
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        private bool _hasSearchResults;
        public bool HasSearchResults
        {
            get { return _hasSearchResults; }
            private set
            {
                if (value == _hasSearchResults) return;
                _hasSearchResults = value;
                OnPropertyChanged("HasSearchResults");
            }
        }
     
        #endregion

        #region --  Commamds  --

        public ICommand SearchCommand { get; private set; }
        public ICommand AddMusicVideoCommand { get; private set; }

        #endregion

        public override string Title
        {
            get { return "Music Video Clips"; }
        }

        #region --  Private Methods  --

        private void Search()
        {
            // ToDo: Put this on a BackgroundWorker thread
            Items = _mvRepository.SearchVideoItems(SearchText);
        }

        private void AddMusicVideo()
        {
            
        }

        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MediaLibraryEditor.WPF.Commands;
using System.Windows.Input;

namespace MediaLibraryEditor.WPF.ViewModels
{
    public class ModuleSelectionViewModel : ViewModelBase
    {

        #region --  ICommand  --

        private DelegateCommand _musicImportCommand;
        private DelegateCommand _musicEditGenreCommand;
        private DelegateCommand _musicEditArtistCommand;
        private DelegateCommand _musicEditSongCommand;

        // --  Properties  -- //

        public ICommand MusicImportCommand
        {
            get
            {
                if (_musicImportCommand == null)
                {
                    _musicImportCommand = new DelegateCommand(MusicImport);
                }
                return _musicImportCommand;
            }
        }

        public ICommand MusicEditGenreCommand
        {
            get
            {
                if (_musicEditGenreCommand == null)
                {
                    _musicEditGenreCommand = new DelegateCommand(MusicEditGenre);
                }
                return _musicEditGenreCommand;
            }
        }

        public ICommand MusicEditArtistCommand
        {
            get
            {
                if (_musicEditArtistCommand == null)
                {
                    _musicEditArtistCommand = new DelegateCommand(MusicEditArtist);
                }
                return _musicEditArtistCommand;
            }
        }

        public ICommand MusicEditSongCommand
        {
            get
            {
                if (_musicEditSongCommand == null)
                {
                    _musicEditSongCommand = new DelegateCommand(MusicEditSong);
                }
                return _musicEditSongCommand;
            }
        }


        // --  Methods  -- //

        public void MusicImport()
        {
        }

        public void MusicEditGenre()
        {
        }

        public void MusicEditArtist()
        {
        }

        public void MusicEditSong()
        {
        }

        #endregion


    }
}

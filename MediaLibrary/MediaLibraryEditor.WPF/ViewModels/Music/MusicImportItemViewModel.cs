using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaLibraryEditor.WPF.ViewModels.Music
{
    public class MusicImportItemViewModel : ViewModelBase
    {
        private string _filename;
        private long _fileSize;
        private DateTime _fileLastModified;

        private string _songName;
        private string _artistName;
        private string _notes;

        #region --  Properties  --

        public string Filename
        {
            get { return _filename; }
            set
            {
                if (value != _filename)
                {
                    _filename = value;
                    OnPropertyChanged("Filename");
                }
            }
        }

        public long FileSize
        {
            get { return _fileSize; }
            set
            {
                if (value != _fileSize)
                {
                    _fileSize = value;
                    OnPropertyChanged("FileSize");
                }
            }
        }

        public DateTime FileLastModified
        {
            get { return _fileLastModified; }
            set
            {
                if (value != _fileLastModified)
                {
                    _fileLastModified = value;
                    OnPropertyChanged("FileLastModified");
                }
            }
        }


        public string SongName
        {
            get { return _songName; }
            set
            {
                if (value != _songName)
                {
                    _songName = value;
                    OnPropertyChanged("SongName");
                }
            }
        }

        
        public string ArtistName
        {
            get { return _artistName; }
            set
            {
                if (value != _artistName)
                {
                    _artistName = value;
                    OnPropertyChanged("ArtistName");
                }
            }
        }

        public string Notes
        {
            get { return _notes; }
            set
            {
                if (value != _notes)
                {
                    _notes = value;
                    OnPropertyChanged("Notes");
                }
            }
        }

        #endregion

    }
}

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Input;

using MediaLibraryEditor.WPF.Commands;
using MediaLibraryEditor.WPF.Models;

namespace MediaLibraryEditor.WPF.ViewModels.Music
{
    public class MusicImportViewModel : OperationViewModelBase
    {

        private MediaCatalogueEntities _ctx;
        private ObservableCollection<MusicImportItemViewModel> _items = new ObservableCollection<MusicImportItemViewModel>();

        private string _folderToScan;

        private int _filesFound;


        //private readonly string MusicClipFilenameRegex = @"^(?<Song>.*)\s-\s(?<Artist>.*?)((\s\[)(?<Notes>.*)(\]))?\.(?<FileExtension>\S*)$";
        private readonly Regex _songFilenameRegex = new Regex(@"^(?<Song>.*)\s-\s(?<Artist>.*?)((\s\[)(?<Notes>.*)(\]))?\.(?<FileExtension>\S*)$");


        #region --  Constructor  --

        public MusicImportViewModel()
        {
            _ctx = new MediaCatalogueEntities();
        }

        #endregion

        #region --  Properties  --

        public ObservableCollection<MusicImportItemViewModel> Items
        {
            get { return _items; }
            set
            {
                if (value != _items)
                {
                    _items = value;
                    OnPropertyChanged("Items");
                }
            }
        }

        public override string Title
        {
            get
            {
                return "Music - Import";
            }
        }

        public string FolderToScan
        {
            get { return _folderToScan; }
            set
            {
                if (value != _folderToScan)
                {
                    _folderToScan = value;
                    OnPropertyChanged("FolderToScan");
                }
            }
        }

        public int FilesFound
        {
            get { return _filesFound; }
            set
            {
                if (value != _filesFound)
                {
                    _filesFound = value;
                    OnPropertyChanged("FilesFound");
                }
            }
        }

        #endregion

        #region --  ICommand  --

        private DelegateCommand _scanFolderCommand;
        private DelegateCommand _showSongsCommand;
        private DelegateCommand _importSongsCommand;

        public ICommand ScanFolderCommand
        {
            get
            {
                if (_scanFolderCommand == null)
                {
                    _scanFolderCommand = new DelegateCommand(ScanFolder, CanScanFolder);
                }
                return _scanFolderCommand;
            }
        }

        public ICommand ShowSongsCommand
        {
            get
            {
                if (_showSongsCommand == null)
                {
                    _showSongsCommand = new DelegateCommand(ShowSongs, CanShowSongs);
                }
                return _showSongsCommand;
            }
        }

        public ICommand ImportSongsCommand
        {
            get
            {
                if (_importSongsCommand == null)
                {
                    _importSongsCommand = new DelegateCommand(ImportSongs, CanImportSongs);
                }
                return _importSongsCommand;
            }
        }

        private void ScanFolder()
        {
            var bgWorker = new BackgroundWorker();
            bgWorker.DoWork += BackgroundScanFolder;
            bgWorker.RunWorkerCompleted += BackgroundScanFolder_Completed;
            bgWorker.RunWorkerAsync();
        }


        private bool CanScanFolder()
        {
            return Directory.Exists(FolderToScan);
        }

        private void ShowSongs()
        {
        }

        private bool CanShowSongs()
        {
            return Items != null && Items.Count > 0;
        }

        private void ImportSongs()
        {

            var musicVidType = MediaCatalogueHelper.GetMusicVideoType(_ctx);

            //List<Media_Item> songItems = new List<Media_Item>();

            foreach (var song in Items)
            {

                var songFileInfo = new Media_File
                {
                    id = Guid.NewGuid(),
                    Filename = song.Filename,
                    ModifiedDate = song.FileLastModified,
                    Size = song.FileSize
                };
                
                var songItem = new Media_Item()
                                   {
                                       id = Guid.NewGuid(),
                                       Title = song.SongName,
                                       Description = "by " + song.ArtistName,
                                       Media_Type = musicVidType
                                   };

                


                // Check for duplicates...

                var existingFile = (from mf in _ctx.Media_File
                                    where mf.Filename == songFileInfo.Filename &&
                                          //mf.ModifiedDate.Value == songFileInfo.ModifiedDate //&&
                                          mf.Size == songFileInfo.Size
                                    select mf).Count();

                if (existingFile == 0)
                {
                    songFileInfo.Media_Item.Add(songItem);
                    _ctx.AddToMedia_File(songFileInfo);
                }

            }

            _ctx.SaveChanges();

        }

        private bool CanImportSongs()
        {
            return Items != null && Items.Count > 0;
        }

        #endregion

        #region --  Private Methods  --

        private void BackgroundScanFolder(object sender, DoWorkEventArgs e)
        {
            BGScanFolder(FolderToScan);
            FilesFound = Items.Count;
        }

        void BackgroundScanFolder_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            ((DelegateCommand)ShowSongsCommand).RaiseCanExecuteChanged();
            ((DelegateCommand)ImportSongsCommand).RaiseCanExecuteChanged();
        }

        private void BGScanFolder(string folder)
        {
            if (!Directory.Exists(folder))
            {
                return;
            }

            var di = new DirectoryInfo(folder);

            // Scan files in this folder
            var files = di.GetFiles();

            foreach (var file in files)
            {
                if (file.Extension.ToLower() == ".mpg" ||
                    file.Extension.ToLower() == ".mpeg" ||
                    file.Extension.ToLower() == ".avi")
                {
                    var song = new MusicImportItemViewModel()
                    {
                        Filename = file.Name,
                        FileLastModified = file.LastWriteTime,
                        FileSize = file.Length
                    };

                    // Decode filename
                    var match = _songFilenameRegex.Match(file.Name);
                    if (match.Success)
                    {
                        song.SongName = match.Groups["Song"].Value;
                        song.ArtistName = match.Groups["Artist"].Value;
                        song.Notes = match.Groups["Notes"].Value;
                    }

                    Items.Add(song);

                }

            }

            // Recurse Subdirectories
            foreach (var subfolder in di.GetDirectories())
            {
                BGScanFolder(subfolder.FullName);
            }



        }

        #endregion

    }
}

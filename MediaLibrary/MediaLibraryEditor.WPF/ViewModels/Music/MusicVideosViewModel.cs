using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

using MediaLibraryEditor.WPF.MusicVideoServiceReference;

namespace MediaLibraryEditor.WPF.ViewModels.MusicVideo
{
    class MusicVideosViewModel : OperationViewModelBase
    {

        MusicVideoServiceReference.MusicVideoServiceClient _client;

        ObservableCollection<MusicArtist> _artists;


        public MusicVideosViewModel()
        {
            _client = new MusicVideoServiceReference.MusicVideoServiceClient();

            Artists = new ObservableCollection<MusicArtist>(_client.GetArtists());


        }


        #region --  Properties  --

        public ObservableCollection<MusicVideoServiceReference.MusicArtist> Artists
        {
            get { return _artists; }
            private set
            {
                if (value == _artists) { return; }
                _artists = value;
                OnPropertyChanged("Artists");
            }
        }


        #endregion




        public override string Title
        {
            get { return "Music Video Clips"; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaLibraryEditor.WPF.ViewModels.Music
{
    class MusicVideosViewModel : OperationViewModel
    {

        public MusicVideosViewModel()
        {
            var svc = new MusicVideoServiceReference.MusicVideoServiceClient();

            var artists = svc.GetArtists();

        }


        public override string Title
        {
            get { return "Music Video Clips"; }
        }
    }
}

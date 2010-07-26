using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MediaLibraryEditor.WPF.Models.MusicVideo
{
    public class MusicVideoItem
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public int PlayLength { get; set; }
        public string Genre { get; set; }

        public Bitmap Screenshot { get; set; }

        // Extended Attributes
        public MediaFileInfo FileInfo { get; set; }


        public bool HasMediaFileInformation()
        {
            return FileInfo != null;
        }

    }
}

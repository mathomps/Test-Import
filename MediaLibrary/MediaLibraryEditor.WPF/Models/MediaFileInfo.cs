using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaLibraryEditor.WPF.Models
{
    public class MediaFileInfo
    {

        public string Filename { get; set; }
        public long Size { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}

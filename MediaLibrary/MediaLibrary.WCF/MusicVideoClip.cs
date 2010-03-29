using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace MediaLibrary.WCF
{
    [DataContract]
    public class MusicVideoClip
    {
        [DataMember]
        public Guid id { get; set; }

        [DataMember]
        public string SongName { get; set; }

        [DataMember]
        public string Artist { get; set; }

        [DataMember]
        public string Genre { get; set; }

        [DataMember]
        public int Duration { get; set; }

    }
}

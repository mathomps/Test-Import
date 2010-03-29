using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace MediaLibrary.WCF
{
    [DataContract]
    public class MusicGenre
    {

        [DataMember]
        public Guid id { get; set; }

        [DataMember]
        public string Description { get; set; }

    }
}

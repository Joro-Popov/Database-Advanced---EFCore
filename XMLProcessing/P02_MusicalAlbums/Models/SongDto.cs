using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace P02_MusicalAlbums.Models
{
    [XmlType("song")]
    public class SongDto
    {
        [XmlAttribute(AttributeName = "title")]
        public string Title { get; set; }

        [XmlAttribute(AttributeName = "length")]
        public string Duration { get; set; }
    }
}

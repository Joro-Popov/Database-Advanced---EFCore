namespace P02_MusicalAlbums.Models
{
    using System.Xml.Serialization;

    [XmlType("album")]
    public class AlbumDto
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "artist")]
        public string Artist { get; set; }

        [XmlElement(ElementName = "year")]
        public int Year { get; set; }

        [XmlElement(ElementName = "producer")]
        public string Producer { get; set; }

        [XmlElement(ElementName = "price")]
        public decimal Price { get; set; }

        [XmlArray(ElementName = "songs")]
        public SongDto[] Songs { get; set; }
    }
}

namespace Instagraph.Models.DTOs
{
    using System;
    using System.Xml.Serialization;

    [XmlType("user")]
    public class ExportUserPostsDto
    {
        [XmlElement()]
        public string Username { get; set; }

        [XmlElement()]
        public int MostComments { get; set; }
    }
}

namespace Instagraph.Models.DTOs
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("post")]
    public class PostDto
    {
        [XmlElement(ElementName = "caption")]
        [Required]
        public string Caption { get; set; }

        [XmlElement(ElementName = "user")]
        [MaxLength(30)]
        [Required]
        public string Username { get; set; }

        [XmlElement(ElementName = "picture")]
        [Required]
        public string PicturePath { get; set; }
    }
}

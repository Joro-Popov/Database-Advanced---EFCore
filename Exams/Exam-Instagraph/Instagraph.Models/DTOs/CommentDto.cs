namespace Instagraph.Models.DTOs
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("comment")]
    public class CommentDto
    {
        [XmlElement(ElementName = "content")]
        [MaxLength(250)]
        [Required]
        public string Content { get; set; }

        [XmlElement(ElementName = "user")]
        [MaxLength(30)]
        [Required]
        public string Username { get; set; }

        [XmlElement(ElementName = "post")]
        public CommentPostDto Post { get; set; }
    }
}

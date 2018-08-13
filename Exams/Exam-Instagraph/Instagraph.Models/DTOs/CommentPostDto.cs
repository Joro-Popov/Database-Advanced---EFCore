namespace Instagraph.Models.DTOs
{
    using System;
    using System.Xml.Serialization;

    public class CommentPostDto
    {
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }
    }
}

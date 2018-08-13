namespace SoftJail.DataProcessor.ExportDto
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlType("Prisoner")]
    public class PrisonerDto
    {
        [XmlElement]
        public int Id { get; set; }

        [XmlElement()]
        public string Name { get; set; }

        [XmlElement]
        public string IncarcerationDate { get; set; }

        [XmlArray()]
        public List<EncryptedMessageDto> EncryptedMessages { get; set; }
    }
}

namespace SoftJail.DataProcessor.ExportDto
{
    using System;
    using System.Xml.Serialization;

    [XmlType("Message")]
    public class EncryptedMessageDto
    {
        public string Description { get; set; }
    }
}

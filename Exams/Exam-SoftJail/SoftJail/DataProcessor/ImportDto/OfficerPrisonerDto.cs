namespace SoftJail.DataProcessor.ImportDto
{
    using System.Xml.Serialization;

    [XmlType("Prisoner")]
    public class OfficerPrisonerDto
    {
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }
    }
}

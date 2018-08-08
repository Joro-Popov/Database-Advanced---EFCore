namespace FastFood.DataProcessor.Dto.Export
{
    using System.Xml.Serialization;

    [XmlType()]
    public class MostPopularItemDto
    {
        [XmlElement()]
        public string Name { get; set; }

        [XmlElement()]
        public decimal TotalMade { get; set; }

        [XmlElement]
        public int TimesSold { get; set; }
    }
}

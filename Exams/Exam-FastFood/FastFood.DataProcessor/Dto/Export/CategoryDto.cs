namespace FastFood.DataProcessor.Dto.Export
{
    using System;
    using System.Xml.Serialization;

    [XmlType("Category")]
    public class CategoryDto
    {
        [XmlElement()]
        public string Name { get; set; }

        [XmlElement()]
        public MostPopularItemDto MostPopularItem { get; set; }
    }
}

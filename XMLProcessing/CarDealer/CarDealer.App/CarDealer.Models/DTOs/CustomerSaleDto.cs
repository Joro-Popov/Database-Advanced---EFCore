namespace CarDealer.Models.DTOs
{
    using System;
    using System.Xml.Serialization;

    [XmlType("customer")]
    public class CustomerSaleDto
    {
        [XmlAttribute(AttributeName = "full-name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "bought-cars")]
        public int BoughtCars { get; set; }

        [XmlAttribute(AttributeName = "spent-money")]
        public decimal SpentMoney { get; set; }
    }
}

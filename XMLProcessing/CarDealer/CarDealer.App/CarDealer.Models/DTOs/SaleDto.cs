namespace CarDealer.Models.DTOs
{
    using System.Xml.Serialization;

    [XmlType("sale")]
    public class SaleDto
    {
        [XmlElement(ElementName ="car")]
        public SaleCarDto Car { get; set; }

        [XmlElement(ElementName = "customer-name")]
        public string CustomerName { get; set; }

        [XmlElement(ElementName = "discount")]
        public int Discount { get; set; }

        [XmlElement(ElementName = "price")]
        public decimal Price { get; set; }

        [XmlElement(ElementName = "price-with-discount")]
        public decimal PriceWithDiscount
        {
            get { return Price -= (Price * (Discount /100.00m)); }
            set { }
        }
    }
}

namespace CarDealer.Models.DTOs
{
    using Newtonsoft.Json;

    public class SaleDiscountDto
    {
        [JsonProperty(PropertyName = "car")]
        public CarsDto Car { get; set; }

        [JsonProperty(PropertyName = "customerName")]
        public string CustomerName { get; set; }

        public decimal Discount { get; set; }

        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "priceWithDiscount")]
        public decimal PriceWithDiscount
        {
            get { return Price -= (Price * Discount); }
            set { }
        }
    }
}
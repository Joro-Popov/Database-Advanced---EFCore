namespace CarDealer.Models.DTOs
{
    using Newtonsoft.Json;

    public class CustomerSaleDto
    {
        [JsonProperty(PropertyName = "fullName")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "boughtCars")]
        public int BoughtCars { get; set; }

        [JsonProperty(PropertyName = "spentMoney")]
        public decimal SpentMoney { get; set; }
    }
}
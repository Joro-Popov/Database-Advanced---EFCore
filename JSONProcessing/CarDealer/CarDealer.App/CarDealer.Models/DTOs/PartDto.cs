namespace CarDealer.Models.DTOs
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class PartDto
    {
        [JsonProperty(PropertyName = "name")]
        [MinLength(3)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }
    }
}
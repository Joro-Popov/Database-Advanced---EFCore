namespace ProductShop.Models.DTOs
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    
    public class ProductDto
    {
        [JsonProperty(PropertyName = "name")]
        [MinLength(3)]
        public string Name { get; set; }
        
        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "buyerFirstName")]
        public string BuyerFirstName { get; set; }

        [JsonProperty(PropertyName = "buyerLastName")]
        public string BuyerLastName { get; set; }
    }
}
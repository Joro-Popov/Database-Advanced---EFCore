namespace ProductShop.Models.DTOs
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    
    public class ProductRangeDto
    {
        [JsonProperty(PropertyName = "name")]
        [MinLength(3)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "seller")]
        public string SellerName { get; set; }
    }
}
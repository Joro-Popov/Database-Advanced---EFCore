namespace ProductShop.Models.DTOs
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
    
    public class ProductUserDto
    {
        [JsonProperty(PropertyName = "name")]
        [MinLength(3)]
        public string Name { get; set; }
        
        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }
    }
}
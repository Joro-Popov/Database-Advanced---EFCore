namespace ProductShop.Models.DTOs
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    
    public class SoldProductsDto
    {
        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }
        
        [JsonProperty(PropertyName = "products")]
        public List<ProductUserDto> Products { get; set; }
    }
}
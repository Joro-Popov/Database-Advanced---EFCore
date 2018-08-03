namespace ProductShop.Models.DTOs
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    
    public class UserProductsDto
    {
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }
        
        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }
        
        [JsonProperty(PropertyName = "soldProducts")]
        public List<ProductDto> Products { get; set; }
    }
}
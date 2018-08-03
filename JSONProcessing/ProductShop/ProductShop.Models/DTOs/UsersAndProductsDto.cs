using Newtonsoft.Json;

namespace ProductShop.Models.DTOs
{
    public class UsersAndProductsDto
    {
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }
        
        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }
        
        [JsonProperty(PropertyName = "age")]
        public int? Age { get; set; }
        
        [JsonProperty(PropertyName = "SoldProducts")]
        public SoldProductsDto SoldProduct { get; set; }
    }
}
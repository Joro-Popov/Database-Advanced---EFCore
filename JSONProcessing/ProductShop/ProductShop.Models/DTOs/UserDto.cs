namespace ProductShop.Models.DTOs
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    
    public class UserDto
    {
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }
        
        [JsonProperty(PropertyName = "lastName")]
        [MinLength(3)]
        public string LastName { get; set; }
        
        [JsonProperty(PropertyName = "age")]
        public string Age { get; set; }
    }
}
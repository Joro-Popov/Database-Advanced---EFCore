namespace ProductShop.Models.DTOs
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    
    public class UsersDto
    {
        [JsonProperty(PropertyName = "usersCount")]
        public int Count { get; set; }
        
        [JsonProperty(PropertyName = "users")]
        public List<UsersAndProductsDto> Users { get; set; }
    }
}
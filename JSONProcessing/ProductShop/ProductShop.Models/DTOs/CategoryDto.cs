namespace ProductShop.Models.DTOs
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
    
    public class CategoryDto
    {
        [JsonProperty(PropertyName = "name")]
        [MinLength(3)]
        [MaxLength(15)]
        public string Name { get; set; }
    }
}
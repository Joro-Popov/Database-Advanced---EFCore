using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ProductShop.Models.DTOs
{
    public class CategoryProductDto
    {
        [JsonProperty(PropertyName = "category")]
        [MinLength(3)]
        [MaxLength(15)]
        public string Name { get; set; }
        
        [JsonProperty(PropertyName = "productsCount")]
        public int NumberOfProducts { get; set; }
        
        [JsonProperty(PropertyName = "averagePrice")]
        public decimal AveragePrice { get; set; }
        
        [JsonProperty(PropertyName = "totalRevenue")]
        public decimal TotalRevenue { get; set; }
    }
}
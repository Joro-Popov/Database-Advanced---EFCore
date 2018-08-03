using Newtonsoft.Json;

namespace CarDealer.Models.DTOs
{
    [JsonObject(Title = "parts")]
    public class PartSupplierDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
namespace CarDealer.Models.DTOs
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class SupplierDto
    {
        [JsonProperty(PropertyName = "name")]
        [MinLength(3)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "isImporter")]
        public bool IsImporter { get; set; }
    }
}
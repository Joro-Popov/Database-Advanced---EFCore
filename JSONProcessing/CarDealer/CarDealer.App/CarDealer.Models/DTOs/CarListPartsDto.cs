namespace CarDealer.Models.DTOs
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class CarListPartsDto
    {
        [JsonProperty(PropertyName = "car")]
        public CarsDto Car { get; set; }

        [JsonProperty(PropertyName = "parts")]
        public List<PartSupplierDto> Parts { get; set; }
    }
}
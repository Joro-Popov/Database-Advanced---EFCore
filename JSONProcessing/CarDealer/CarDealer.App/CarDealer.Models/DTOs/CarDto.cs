namespace CarDealer.Models.DTOs
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class CarDto
    {
        [JsonProperty(PropertyName = "make")]
        [MinLength(3)]
        public string Make { get; set; }

        [JsonProperty(PropertyName = "model")]
        [MinLength(3)]
        public string Model { get; set; }

        [JsonProperty(PropertyName = "travelledDistance")]
        public ulong TravelledDistance { get; set; }
    }
}
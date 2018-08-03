namespace CarDealer.Models.DTOs
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CustomerDto
    {
        [JsonProperty(PropertyName = "name")]
        [MinLength(3)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "birthData")]
        [Required]
        public DateTime BirthDate { get; set; }

        [JsonProperty(PropertyName = "isYoungDriver")]
        public bool IsYounger { get; set; }
    }
}
namespace CarDealer.Models.DTOs
{
    using CarDealer.Models.DomainModels;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class OrderedCustomerDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsYounger { get; set; }

        [JsonProperty(ReferenceLoopHandling = ReferenceLoopHandling.Ignore)]
        public ICollection<Sale> Sales { get; set; }
    }
}
﻿namespace FastFood.DataProcessor.Dto.Import
{
    using System.ComponentModel.DataAnnotations;
    
    public class ItemDto
    {
        [MinLength(3)]
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        [Required]
        public decimal Price { get; set; }

        [MinLength(3)]
        [MaxLength(30)]
        [Required]
        public string Category { get; set; }
    }
}

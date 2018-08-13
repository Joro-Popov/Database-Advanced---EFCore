namespace SoftJail.DataProcessor.ImportDto
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CellDto
    {
        [Range(1, 1000)]
        [Required]
        public int CellNumber { get; set; }

        [Required]
        public bool HasWindow { get; set; }
    }
}

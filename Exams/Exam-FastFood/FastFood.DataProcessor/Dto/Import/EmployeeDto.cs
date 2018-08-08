namespace FastFood.DataProcessor.Dto.Import
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class EmployeeDto
    {
        [MinLength(3)]
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        [Range(15, 80)]
        [Required]
        public int Age { get; set; }

        [MinLength(3)]
        [MaxLength(30)]
        [Required]
        public string Position { get; set; }
    }
}

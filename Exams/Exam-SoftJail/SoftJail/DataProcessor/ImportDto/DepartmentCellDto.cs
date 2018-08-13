namespace SoftJail.DataProcessor.ImportDto
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class DepartmentCellDto
    {
        [MinLength(3)]
        [MaxLength(25)]
        [Required]
        public string Name { get; set; }

        public List<CellDto> Cells { get; set; } 
    }
}

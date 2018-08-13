﻿namespace SoftJail.DataProcessor.ImportDto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class PrisonerDto
    {
        [MinLength(3)]
        [MaxLength(20)]
        [Required]
        public string FullName { get; set; }

        [RegularExpression(@"^The [A-Z][a-z]+$")]
        [Required]
        public string Nickname { get; set; }

        [Range(18, 65)]
        [Required]
        public int Age { get; set; }

        [Required]
        public string IncarcerationDate { get; set; }

        public string ReleaseDate { get; set; }

        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal? Bail { get; set; }

        public int? CellId { get; set; }

        public List<MailDto> Mails { get; set; }
    }
}

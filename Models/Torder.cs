using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DFA_CORE.Models
{
    public partial class Torder
    {
        [Key]
        public int Oid { get; set; }

        [Required(ErrorMessage = "Enter Your Name")]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "Name must consist of minimum 4 characters")]
        [RegularExpression(@"^([A-Za-z]+)$")]
        public string? Oname { get; set; }

        [Required(ErrorMessage = "Enter Item Name")]
        [RegularExpression(@"^([A-Za-z]+)$")]
        public string? Oitem { get; set; }

        [Range(1, 15, ErrorMessage = "Plese Enter the quantity between 1-15")]
        public int? Oquant { get; set; }
    }
}

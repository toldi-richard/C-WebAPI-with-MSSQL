using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Diakok051.Models
{
    [Index(nameof(DiakNev), Name = "DiakNev")]
    [Index(nameof(DiakNev), Name = "UQ__Diak__A0B468016F76B9CD", IsUnique = true)]
    public partial class Diak
    {
        [Key]
        public byte DiakID { get; set; }
        public byte? OsztalyID { get; set; }
        [Required]
        [StringLength(50)]
        public string DiakNev { get; set; }

        [ForeignKey(nameof(OsztalyID))]
        [InverseProperty("Diak")]
        public virtual Osztaly Osztaly { get; set; }
    }
}

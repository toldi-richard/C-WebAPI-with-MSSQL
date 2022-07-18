using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Diakok051.Models
{
    [Index(nameof(OsztalyJeloles), Name = "OsztalyJeloles")]
    [Index(nameof(OsztalyJeloles), Name = "UQ__Osztaly__E9A8F8A41B617A21", IsUnique = true)]
    public partial class Osztaly
    {
        public Osztaly()
        {
            Diak = new HashSet<Diak>();
        }

        [Key]
        public byte OsztalyID { get; set; }
        public byte? TanarID { get; set; }
        [Required]
        [StringLength(5)]
        public string OsztalyJeloles { get; set; }

        [ForeignKey(nameof(TanarID))]
        [InverseProperty("Osztaly")]
        public virtual Tanar Tanar { get; set; }
        [InverseProperty("Osztaly")]
        public virtual ICollection<Diak> Diak { get; set; }
    }
}

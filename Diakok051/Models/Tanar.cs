using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Diakok051.Models
{
    [Index(nameof(TanarNev), Name = "TanarNev")]
    [Index(nameof(TanarNev), Name = "UQ__Tanar__E783DA2F96B88AFD", IsUnique = true)]
    public partial class Tanar
    {
        public Tanar()
        {
            Osztaly = new HashSet<Osztaly>();
        }

        [Key]
        public byte TanarID { get; set; }
        [Required]
        [StringLength(50)]
        public string TanarNev { get; set; }
        [Required]
        [StringLength(80)]
        public string OktatottTargy { get; set; }

        [InverseProperty("Tanar")]
        public virtual ICollection<Osztaly> Osztaly { get; set; }
    }
}

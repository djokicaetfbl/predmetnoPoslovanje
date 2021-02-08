using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PredmetnoPoslovanjeNetCore.Models
{
    public partial class Predmet
    {
        public Predmet()
        {
            Akt = new HashSet<Akt>();
        }

        [Key]
        public int IdPredmeta { get; set; }
        [Column(TypeName = "date")]
        public DateTime DatumOtvaranja { get; set; }
        [Required]
        [StringLength(20)]
        public string VrstaPredmeta { get; set; }
        [Required]
        [StringLength(100)]
        public string NazivPredmeta { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string Napomena { get; set; }

        [InverseProperty("IdPredmetaNavigation")]
        public virtual ICollection<Akt> Akt { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PredmetnoPoslovanjeNetCore.Models
{
    public partial class Akt
    {
        [Key]
        public int IdAkta { get; set; }
        [Column(TypeName = "date")]
        public DateTime DatumPrijema { get; set; }
        [Required]
        [StringLength(64)]
        public string NazivAkta { get; set; }
        [Required]
        [StringLength(64)]
        public string Posiljalac { get; set; }
        public int? IdPredmeta { get; set; }

        [ForeignKey(nameof(IdPredmeta))]
        [InverseProperty(nameof(Predmet.Akt))]
        public virtual Predmet IdPredmetaNavigation { get; set; }
    }
}

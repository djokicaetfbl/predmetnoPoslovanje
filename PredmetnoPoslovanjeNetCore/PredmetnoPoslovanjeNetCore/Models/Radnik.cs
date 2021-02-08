using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PredmetnoPoslovanjeNetCore.Models
{
    public partial class Radnik
    {
        [Key]
        public int IdRadnika { get; set; }
        [Required]
        [Column("ImeIPrezime")]
        [StringLength(64)]
        public string ImeIprezime { get; set; }
        [Column(TypeName = "date")]
        public DateTime DatumZaposljavanja { get; set; }
        [StringLength(64)]
        public string Pozicija { get; set; }
        [StringLength(64)]
        public string Sektor { get; set; }
        [StringLength(64)]
        public string BrojTelefona { get; set; }
    }
}

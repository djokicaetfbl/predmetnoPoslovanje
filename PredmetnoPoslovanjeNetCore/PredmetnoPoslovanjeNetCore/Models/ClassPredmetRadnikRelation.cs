using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PredmetnoPoslovanjeNetCore.Models
{
    public partial class ClassPredmetRadnikRelation
    {
        public int IdPredmeta { get; set; }
        public int IdRadnika { get; set; }

        [ForeignKey(nameof(IdPredmeta))]
        public virtual Predmet IdPredmetaNavigation { get; set; }
        [ForeignKey(nameof(IdRadnika))]
        public virtual Radnik IdRadnikaNavigation { get; set; }
    }
}

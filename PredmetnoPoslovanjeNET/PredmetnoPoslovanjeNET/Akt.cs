using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PredmetnoPoslovanjeNET
{
    public class Akt
    {
        public int IdAkta { get; set; }
        public DateTime DatumPrijema { get; set; }
        public string NazivAkta { get; set; }
        public string Posiljalac { get; set; }
        public int IdPredmeta { get; set; }

        Akt() {}

        public Akt(DateTime datumPrijema, string nazivAkta, string posiljalac, int idPredmeta)
        {
            DatumPrijema = datumPrijema;
            NazivAkta = nazivAkta;
            Posiljalac = posiljalac;
            IdPredmeta = idPredmeta;
        }
    }
}
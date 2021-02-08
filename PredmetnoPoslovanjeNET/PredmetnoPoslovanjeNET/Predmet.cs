using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PredmetnoPoslovanjeNET
{
    public class Predmet
    {
        public int IdPredmeta { get; set; }
        public DateTime DatumOtvaranja { get; set; }
        public string VrstaPredmeta { get; set; }
        public string NazivPredmeta { get; set; }
        public string Napomena { get; set; }

        Predmet()
        {

        }

        public Predmet(DateTime datumOtvaranja, string vrstaPredmeta, string nazivPredmeta, string napomena)
        {
            DatumOtvaranja = datumOtvaranja;
            VrstaPredmeta = vrstaPredmeta;
            NazivPredmeta = nazivPredmeta;
            Napomena = napomena;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PredmetnoPoslovanjeNET
{
    public class Radnik
    {
        public int IdRadnika { get; set; }
        public string ImeIPrezime { get; set; }
        public string Pozicija { get; set; }
        public string Sektor { get; set; }
        public int BrojTelefona { get; set; }
        public DateTime DatumZaposljavanja { get; set; }

        Radnik() { }

        public Radnik(string imeIPrezime, string pozicija, string sektor, int brojTelefona, DateTime datumZaposljavanja)
        {
            ImeIPrezime = imeIPrezime;
            Pozicija = pozicija;
            Sektor = sektor;
            BrojTelefona = brojTelefona;
            DatumZaposljavanja = datumZaposljavanja;
        }
    }
}
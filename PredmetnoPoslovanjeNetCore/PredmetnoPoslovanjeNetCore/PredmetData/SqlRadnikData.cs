using PredmetnoPoslovanjeNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PredmetnoPoslovanjeNetCore.PredmetData
{
    public class SqlRadnikData : IRadnikData
    {
        private PredmetnoPoslovanjeContext _predmetnoPoslovanjeContext;


        public SqlRadnikData(PredmetnoPoslovanjeContext predmetnoPoslovanjeContext)
        {
            _predmetnoPoslovanjeContext = predmetnoPoslovanjeContext;
        }

        public Radnik AddRadnik(Radnik radnik)
        {
            _predmetnoPoslovanjeContext.Radnik.Add(radnik);
            _predmetnoPoslovanjeContext.SaveChanges();

            return radnik;
        }

        public void DeleteRadnik(Radnik radnik)
        {
            _predmetnoPoslovanjeContext.Radnik.Remove(radnik);
            _predmetnoPoslovanjeContext.SaveChanges();
        }

        public Radnik EditRadnik(Radnik radnik)
        {
            var existingRadnik = _predmetnoPoslovanjeContext.Radnik.Find(radnik.IdRadnika);
            if (existingRadnik != null)
            {
                existingRadnik.ImeIprezime = radnik.ImeIprezime;
                existingRadnik.DatumZaposljavanja = radnik.DatumZaposljavanja;
                existingRadnik.Pozicija = radnik.Pozicija;
                existingRadnik.Sektor = radnik.Sektor;
                existingRadnik.BrojTelefona = radnik.BrojTelefona;

                _predmetnoPoslovanjeContext.Radnik.Update(existingRadnik);
                _predmetnoPoslovanjeContext.SaveChanges();
            }
            return radnik;
        }

        public Radnik GetRadnik(int id)
        {
            var radnik = _predmetnoPoslovanjeContext.Radnik.Find(id);
            return radnik;
        }

        public List<Radnik> GetRadniks()
        {
            return _predmetnoPoslovanjeContext.Radnik.ToList();
        }
    }
}

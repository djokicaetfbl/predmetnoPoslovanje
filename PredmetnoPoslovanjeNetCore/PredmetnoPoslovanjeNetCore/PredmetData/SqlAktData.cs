using PredmetnoPoslovanjeNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PredmetnoPoslovanjeNetCore.PredmetData
{
    public class SqlAktData : IAktData
    {
        private PredmetnoPoslovanjeContext _predmetnoPoslovanjeContext;


        public SqlAktData(PredmetnoPoslovanjeContext predmetnoPoslovanjeContext)
        {
            _predmetnoPoslovanjeContext = predmetnoPoslovanjeContext;
        }
        public Akt AddAkt(Akt akt)
        {
            _predmetnoPoslovanjeContext.Akt.Add(akt);
            _predmetnoPoslovanjeContext.SaveChanges();

            return akt;
        }

        public void DeleteAkt(Akt akt)
        {
            _predmetnoPoslovanjeContext.Akt.Remove(akt);
            _predmetnoPoslovanjeContext.SaveChanges();
        }

        public Akt EditAkt(Akt akt)
        {
            var existingAkt = _predmetnoPoslovanjeContext.Akt.Find(akt.IdAkta);
            if (existingAkt != null)
            {
                existingAkt.DatumPrijema = akt.DatumPrijema;
                existingAkt.NazivAkta = akt.NazivAkta;
                existingAkt.Posiljalac = akt.Posiljalac;
                existingAkt.IdPredmeta = akt.IdPredmeta;

                _predmetnoPoslovanjeContext.Akt.Update(existingAkt);
                _predmetnoPoslovanjeContext.SaveChanges();
            }
            return akt;
        }

        public Akt GetAkt(int id)
        {
            var akt = _predmetnoPoslovanjeContext.Akt.Find(id);
            return akt;
        }

        public List<Akt> GetAkts()
        {
            return _predmetnoPoslovanjeContext.Akt.ToList();
        }
    }
}

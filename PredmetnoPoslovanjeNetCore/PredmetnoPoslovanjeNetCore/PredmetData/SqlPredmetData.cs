using PredmetnoPoslovanjeNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PredmetnoPoslovanjeNetCore.PredmetData
{
    public class SqlPredmetData: IPredmetData
    {
        private PredmetnoPoslovanjeContext _predmetnoPoslovanjeContext;


        public SqlPredmetData(PredmetnoPoslovanjeContext predmetnoPoslovanjeContext)
        {
            _predmetnoPoslovanjeContext = predmetnoPoslovanjeContext;
        }

        public Predmet AddPredmet(Predmet predmet)
        {
            _predmetnoPoslovanjeContext.Predmet.Add(predmet);
            _predmetnoPoslovanjeContext.SaveChanges();

            return predmet;
        }

        public void DeletePredmet(Predmet predmet)
        {
            _predmetnoPoslovanjeContext.Predmet.Remove(predmet);
            _predmetnoPoslovanjeContext.SaveChanges();
        }

        public Predmet EditPredmet(Predmet predmet)
        {
            var existingPredmet = _predmetnoPoslovanjeContext.Predmet.Find(predmet.IdPredmeta);
            if (existingPredmet != null)
            {
                existingPredmet.DatumOtvaranja = predmet.DatumOtvaranja;
                existingPredmet.VrstaPredmeta = predmet.VrstaPredmeta;
                existingPredmet.NazivPredmeta = predmet.NazivPredmeta;
                existingPredmet.Napomena = predmet.Napomena;

                _predmetnoPoslovanjeContext.Predmet.Update(existingPredmet);
                _predmetnoPoslovanjeContext.SaveChanges();
            }
            return predmet;
        }

        public Predmet GetPredmet(int id)
        {
            var predmet = _predmetnoPoslovanjeContext.Predmet.Find(id);
            return predmet;
        }

        public List<Predmet> GetPredmets()
        {
            return _predmetnoPoslovanjeContext.Predmet.ToList();
        }
    }
}

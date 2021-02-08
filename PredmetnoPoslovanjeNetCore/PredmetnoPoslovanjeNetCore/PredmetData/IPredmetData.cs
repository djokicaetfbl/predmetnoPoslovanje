using PredmetnoPoslovanjeNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PredmetnoPoslovanjeNetCore.PredmetData
{
    public interface IPredmetData
    {
        List<Predmet> GetPredmets();

        Predmet GetPredmet(int id);

        Predmet AddPredmet(Predmet predmet);

        void DeletePredmet(Predmet predmet);

        Predmet EditPredmet(Predmet predmet);
    }
}

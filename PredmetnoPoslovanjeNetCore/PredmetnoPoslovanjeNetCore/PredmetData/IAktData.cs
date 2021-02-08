using PredmetnoPoslovanjeNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PredmetnoPoslovanjeNetCore.PredmetData
{
    public interface IAktData
    {
        List<Akt> GetAkts();

        Akt GetAkt(int id);

        Akt AddAkt(Akt akt);

        void DeleteAkt(Akt akt);

        Akt EditAkt(Akt akt);
    }
}

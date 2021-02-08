using PredmetnoPoslovanjeNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PredmetnoPoslovanjeNetCore.PredmetData
{
    public interface IRadnikData
    {
        List<Radnik> GetRadniks();

        Radnik GetRadnik(int id);

        Radnik AddRadnik(Radnik radnik);

        void DeleteRadnik(Radnik radnik);

        Radnik EditRadnik(Radnik radnik);
    }
}

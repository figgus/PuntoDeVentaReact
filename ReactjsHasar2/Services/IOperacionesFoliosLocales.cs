using ReactjsHasar2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactjsHasar2.Services
{
    public interface IOperacionesFoliosLocales
    {
        bool ExisteFolio(int numFolio);
        List<Hist_fn> TraerDatosImpresion(int numFolio);
    }
}

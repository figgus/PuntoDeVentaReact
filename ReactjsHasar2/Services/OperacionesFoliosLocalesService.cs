using ReactjsHasar2.DAL;
using ReactjsHasar2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactjsHasar2.Services
{
    public class OperacionesFoliosLocalesService : IOperacionesFoliosLocales
    {
        private readonly ContextoBDMysql _context = new ContextoBDMysql();

        public bool ExisteFolio(int numFolio)
        {
            return _context.FoliosLocal.Count(p=>p.numFolio==numFolio)>0;
        }

        public List<Hist_fn> TraerDatosImpresion(int numFolio)
        {
            if (!this.ExisteFolio(numFolio))
            {
                return new List<Hist_fn>();
            }

            return _context.Hist_fn.Where(p => p.numeroFolio == numFolio).ToList(); ;
        }
    }
}

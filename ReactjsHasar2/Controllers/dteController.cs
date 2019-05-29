using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactjsHasar2.Clases;
using ReactjsHasar2.DAL;
using ReactjsHasar2.Models;
using ReactjsHasar2.Models.ModelsDTE;

namespace ReactjsHasar2.Controllers
{
    [ApiController]
    public class dteController : ControllerBase
    {
        private readonly ContextoBDMysql _context = new ContextoBDMysql();

        [Route("/enviarDTE")]
        [HttpPost]
        public async void EnviarDTE([FromBody]EnvioDTEpara datos)
        {
            foreach (Hist_plu venta in datos.detalles)
            {
                venta.Cantidad = datos.detalles.Count(p=>p.CodigoPLU==venta.CodigoPLU);
            }
            var ventas = datos.detalles.GroupBy(p => p.CodigoPLU).Select(y=>y.First());

            var lista = new List<Detalle>();
            int i = 0;
            foreach (Hist_plu venta in ventas)
            {
                i++;
                lista.Add(PluToDetalle(venta,i));
            }
            EnvioDTE dte = new EnvioDTE();
            await dte.EnviarDetalles(lista,datos.numFolio,datos.tipoDocumento);
        }

        

        private Detalle PluToDetalle(Hist_plu plu,int numLinea)
        {
            int cantidad = Convert.ToInt32(plu.Cantidad);
            string descripcion = _context.plu.FirstOrDefault(p=>p.CodigoPLU==plu.CodigoPLU).Descripcion;
            int precioItem= Convert.ToInt32(plu.Costo);
            int montoItem = precioItem * cantidad;
            return new Detalle {DscItem=descripcion,NroLinDet=numLinea,QtyItem=cantidad,PrcItem=precioItem,MontoItem=montoItem, NmbItem=descripcion ,CdgItem=new CdgItem { } };
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactjsHasar2.Clases;
using ReactjsHasar2.DAL;
using ReactjsHasar2.Models;
using ReactjsHasar2.Models.ModelsDTE;

namespace ReactjsHasar2.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class dteController : ControllerBase
    {
        private readonly ContextoBDMysql _context = new ContextoBDMysql();

        public dteController( )
        {
        }

        [Route("/enviarDTE")]
        [HttpPost]
        public async Task<string> EnviarDTE([FromBody]EnvioDTEpara datos)
        {
            var lista = new List<Detalle>();
            if (datos.detalles != null)
            {
                foreach (Hist_plu venta in datos.detalles)
                {
                    venta.Cantidad = datos.detalles.Count(p => p.CodigoPLU == venta.CodigoPLU);
                }
                var ventas = datos.detalles.GroupBy(p => p.CodigoPLU).Select(y => y.First());


                int i = 0;
                foreach (Hist_plu venta in ventas)
                {
                    i++;
                    lista.Add(PluToDetalle(venta, i));
                }
            }

            EnvioDTE dte = new EnvioDTE();

            EnvioDteApi datosEnvio = new EnvioDteApi { detalles = lista, CmnaDest = datos.CmnaDest,
                tipoDocumento = datos.tipoDocumento,
                IndTraslado = datos.IndTraslado, TpoDocLiq = datos.TpoDocLiq,numFolioReferencia=datos.numFolioReferencia,
                tipoDocumentoRef =datos.tipoDocumentoRef,CodRef=datos.CodRef,FmaPago=datos.FmaPago,CdgTraslado=datos.CdgTraslado};
            string res=  await dte.EnviarDetalles(datosEnvio);
            return res;
        }

        [Route("/AnularVenta")]
        [HttpPost]
        public async Task<ActionResult> AnularVenta(int num)
        {

            return Ok();
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
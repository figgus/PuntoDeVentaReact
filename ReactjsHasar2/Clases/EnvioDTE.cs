using Newtonsoft.Json;
using ReactjsHasar2.Models.ModelsDTE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ReactjsHasar2.Clases
{
    public class EnvioDTE
    {

        public string GetXMLFacturacion(List<Detalle> listaDetalles)
        {
            XElement parent = new XElement("datos");
            XElement res;
            foreach (Detalle detalle in listaDetalles)
            {
                res = new XElement("Detalle");
                res.Add(new XElement("NroLinDet",detalle.NroLinDet));

                //var cdgElem=new XElement("CdgItem");
                //cdgElem.Add(new XElement("tpoCodigo",detalle.CdgItem.TpoCodigo));
                //cdgElem.Add(new XElement("tpoCodigo", detalle.CdgItem.VlrCodigo));
                //res.Add(cdgElem);

                res.Add(new XElement("NmbItem", detalle.NmbItem));
                res.Add(new XElement("DscItem", detalle.DscItem));
                res.Add(new XElement("QtyItem", detalle.QtyItem));
                res.Add(new XElement("PrcItem", detalle.PrcItem));
                res.Add(new XElement("MontoItem", detalle.MontoItem));

                parent.Add(res);
            }

            int mntTotal = listaDetalles.Sum(p=>p.MontoItem);
            var total = new XElement("Totales");
            total.Add(new XElement("MntNeto",mntTotal));
            total.Add(new XElement("TasaIVA",19));
            total.Add(new XElement("IVA",mntTotal*0.19));
            total.Add(new XElement("MntTotal",mntTotal*1.19));

            
            parent.Add(total);
            

            return parent.ToString();
        }

        public async Task<string> EnviarDTE(string datos)
        {
            string res = string.Empty;
            string urlAPI= "";
            var xml = datos;
            var content = new StringContent(xml, Encoding.UTF8, "application/xml");
            HttpClient client = new HttpClient();
            var response = await client.PostAsync(urlAPI, content);
            

            return response.RequestMessage.ToString();
        }

    }
}

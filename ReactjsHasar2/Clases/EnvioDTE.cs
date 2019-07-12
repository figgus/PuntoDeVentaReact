using Newtonsoft.Json;
using ReactjsHasar2.DAL;
using ReactjsHasar2.Models;
using ReactjsHasar2.Models.ModelsDTE;
using ReactjsHasar2.Services.PdfExport;
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
        private readonly ContextoBDMysql _context = new ContextoBDMysql();
        


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

        public async Task<string> EnviarDetalles(EnvioDteApi datos)
        {
            var ajustes = _context.Ajustes.FirstOrDefault();
            datos.NumSucursal = ajustes.numSucursal;
            datos.NumCaja = ajustes.numeroCaja;
            datos.RutCliente = "77441010-4";
            
            string res = string.Empty;
            string urlAPI = "http://localhost:59017/enviarDTE";
            var json = JsonConvert.SerializeObject(datos);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            //client.DefaultRequestHeaders.Add("Content-Length","95267");
            
            var response = await client.PostAsync(urlAPI, content);
            
            var RespAdmFolios = await response.Content.ReadAsStringAsync();
            return RespAdmFolios;
        }

    }
}

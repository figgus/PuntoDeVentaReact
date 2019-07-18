using Newtonsoft.Json;
using ReactjsHasar2.DAL;
using ReactjsHasar2.Models;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ReactjsHasar2.Clases
{
    public class EnvioDTE
    {
        private readonly ContextoBDMysql _context = new ContextoBDMysql();
        public string url { get; set; }

        public EnvioDTE()
        {
            this.url = DatosGlobales.UrlApiLocal;
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

        public async Task<string> EnviarDetalles(EnvioDteApi datos)
        {
            var ajustes = _context.Ajustes.FirstOrDefault();
            datos.NumSucursal = ajustes.numSucursal;
            datos.NumCaja = ajustes.numeroCaja;
            datos.RutCliente = "77441010-4";

            string res = string.Empty;
            string urlAPI = this.url+"/enviarDTE";

            var json = JsonConvert.SerializeObject(datos);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            
            var response = await client.PostAsync(urlAPI, content);
            
            var RespAdmFolios = await response.Content.ReadAsStringAsync();
            return RespAdmFolios;
        }

    }
}

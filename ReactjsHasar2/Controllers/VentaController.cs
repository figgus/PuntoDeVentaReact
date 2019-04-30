using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactjsHasar2.DAL;
using ReactjsHasar2.Models;

namespace ReactjsHasar2.Controllers
{
    [ApiController]
    public class VentaController : ControllerBase
    {
        private static List<Venta> listaValores = new List<Venta>();
        private ContextoBD contexto = new ContextoBD();
        
        [HttpPost]
        [Route("api/valores2")]
        public ActionResult GuardarValor(int valor)
        {
            listaValores.Add(new Venta { Monto=valor});
            return Ok();
        }

        [HttpGet]
        [Route("api/valores")]
        public ActionResult TraerValores(int valor)
        {
          
            return Ok(listaValores);
        }

        [HttpPost]
        [Route("api/valores")]
        public ActionResult PostUsuario(Venta venta)
        {
            //var a = Request.Query["valor"];
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            venta.Fecha = DateTime.Now;
            venta.precioTotal = venta.Monto * venta.Cantidad;
            listaValores.Add(venta);

            return CreatedAtRoute("DefaultApi", venta);
        }

        [HttpGet]
        [Route("test")]
        public void test()
        {

            var a=contexto.Productoes;
        }

        [HttpPost]
        [Route("testcon")]
        public ActionResult prueba(int valor)
        {
            listaValores.Add(new Venta { Monto = valor });
            return Ok();
        }
        //[HttpGet]
        //[Route("traerProductos")]
        //public ActionResult TraerProductos()
        //{
        //    return Ok(contexto.Productoes);
        //}

        //[HttpGet]
        //[Route("traerEncabezados")]
        //public ActionResult TraerEncabezados()
        //{
        //    return Ok(contexto.Encabezadoes);
        //}
    }
}
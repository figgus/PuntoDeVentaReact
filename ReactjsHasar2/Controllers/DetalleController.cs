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
    //[Route("api/[controller]")]
    [ApiController]
    public class DetalleController : ControllerBase
    {
        private ContextoBD contexto = new ContextoBD();
        // GET: api/Detalle
        [HttpGet]
        [Route("api/Detalle")]
        public ActionResult Get()
        {
            return Ok(contexto.Detalles);
        }

        //// GET: api/Detalle/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Detalle
        [Route("api/Detalle")]
        [HttpPost]
        public ActionResult Post(Detalle detalle)
        {

            detalle.MontoSinIva =Convert.ToInt32( detalle.MontoConIva * 0.81);
            detalle.numeroLinea = 0;
            detalle.FechaIngreso = DateTime.Now;
            detalle.EncabezadoID = 3; //quizas cambiar esto
            detalle.Cantidad = 1;
            contexto.Detalles.Add(detalle);
            contexto.SaveChanges();
            return Ok();
        }
        
        // PUT: api/Detalle/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


        [HttpGet]
        [Route("testMysql")]
        public ActionResult testmysql()
        {
            var a = new ContextoBDMysql().libro_iva;
            return Ok(a);
        }
    }
}

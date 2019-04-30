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
    public class EncabezadoesController : ControllerBase
    {
        private ContextoBD contexto = new ContextoBD();
        // GET: api/Encabezadoes
        [HttpGet]
        [Route("api/Encabezado")]
        public ActionResult Get()
        {
            return Ok(contexto.Encabezadoes);
        }

        // GET: api/Encabezadoes/5
        //[HttpGet("{id}", Name = "Get")]
        //public ActionResult Get(int id)
        //{
        //    return Ok(contexto.Encabezadoes.Where(p => p.ID == id).FirstOrDefault());
        //}

        // POST: api/Encabezadoes
        [Route("api/Encabezado")]
        [HttpPost]
        public ActionResult Post(Encabezado encabezado)
        {
            encabezado.FechaIngreso = DateTime.Now;
            encabezado.UserIngreso = "rflores@hasar.cl";

            contexto.Encabezadoes.Add(encabezado);
            contexto.SaveChanges();
            return Ok(encabezado);
        }

        [Route("post2")]
        [HttpPost]
        public void PostUsuario(Encabezado valor)
        {
            
        }



        // PUT: api/Encabezadoes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

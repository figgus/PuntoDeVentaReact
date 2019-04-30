using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactjsHasar2.DAL;

namespace ReactjsHasar2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        ContextoBD contexto = new ContextoBD();
        // GET: api/Productos
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(contexto.Productoes);
        }

        // GET: api/Productos/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult Get(int id)
        {

            return Ok(contexto.Productoes.Where(p=>p.Codigo==id.ToString()));
        }

        // POST: api/Productos
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Productos/5
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactjsHasar2.DAL;
using ReactjsHasar2.Models;

namespace ReactjsHasar2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Historico_rendicionController : ControllerBase
    {
        private readonly ContextoBDMysql _context=new ContextoBDMysql();

        

        // GET: api/Historico_rendicion
        [HttpGet]
        public IEnumerable<Historico_rendicion> GetHistorico_rendicion()
        {
            string fechaFiltro = HttpContext.Request.Query["fecha"].ToString();
            int codigoOperador;
            bool codigoValido = int.TryParse(HttpContext.Request.Query["codigoOperador"].ToString(), out codigoOperador);
            bool fechaValida = fechaFiltro != "";

            if (!fechaValida && !codigoValido)
            {
                return _context.Historico_rendicion;
            }
            if (codigoValido && fechaValida)
            {
                return _context.Historico_rendicion.Where(p => p.Fecha == DateTime.Parse(fechaFiltro) & p.CodigoOperador==codigoOperador);
            }

            if (codigoValido && !fechaValida)
            {
                return _context.Historico_rendicion.Where(p => p.CodigoOperador == codigoOperador);
            }
            if (!codigoValido && fechaValida)
            {
                return _context.Historico_rendicion.Where(p => p.Fecha == DateTime.Now);
            }

            return _context.Historico_rendicion;
        }

        // GET: api/Historico_rendicion/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHistorico_rendicion([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var historico_rendicion = await _context.Historico_rendicion.FindAsync(id);

            if (historico_rendicion == null)
            {
                return NotFound();
            }

            return Ok(historico_rendicion);
        }

        // PUT: api/Historico_rendicion/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistorico_rendicion([FromRoute] int id, [FromBody] Historico_rendicion historico_rendicion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != historico_rendicion.ID)
            {
                return BadRequest();
            }

            _context.Entry(historico_rendicion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Historico_rendicionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Historico_rendicion
        [HttpPost]
        public async Task<IActionResult> PostHistorico_rendicion([FromBody] Historico_rendicion historico_rendicion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Historico_rendicion.Add(historico_rendicion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistorico_rendicion", new { id = historico_rendicion.ID }, historico_rendicion);
        }

        // DELETE: api/Historico_rendicion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorico_rendicion([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var historico_rendicion = await _context.Historico_rendicion.FindAsync(id);
            if (historico_rendicion == null)
            {
                return NotFound();
            }

            _context.Historico_rendicion.Remove(historico_rendicion);
            await _context.SaveChangesAsync();

            return Ok(historico_rendicion);
        }

        private bool Historico_rendicionExists(int id)
        {
            return _context.Historico_rendicion.Any(e => e.ID == id);
        }
    }
}
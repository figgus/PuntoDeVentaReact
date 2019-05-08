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
    public class Hist_fnMediosPagoController : ControllerBase
    {
        private readonly ContextoBDMysql _context=new ContextoBDMysql();

        

        // GET: api/Hist_fnMediosPago
        [HttpGet]
        public IEnumerable<Hist_fn> GetHist_fn()
        {
            string fechaFiltro= HttpContext.Request.Query["fecha"].ToString();
            int codigoOperador;
            bool codigoValido= int.TryParse(HttpContext.Request.Query["codigoOperador"].ToString(),out codigoOperador);
            bool fechaValida = fechaFiltro != "";
            if (!fechaValida && !codigoValido)
            {
                return _context.Hist_fn.Where(p=>p.CodigoFn==103);
            }
            if (codigoValido  && fechaValida)
            {
                return _context.Hist_fn.Where(p=>p.Fecha==DateTime.Parse(fechaFiltro) && p.CodigoFn==103);
            }

            if (codigoValido && !fechaValida)
            {
                return _context.Hist_fn.Where(p=>p.CodigoOperador==codigoOperador);
            }

            return _context.Hist_fn.Where(p=>p.CodigoFn==103 & p.Fecha==DateTime.Parse(fechaFiltro));
        }

        // GET: api/Hist_fnMediosPago/5
        [HttpGet("{idMedioPago}")]
        public async Task<IActionResult> GetHist_fn([FromRoute] int idMedioPago)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hist_fn = await _context.subfuncion.FirstOrDefaultAsync(p=>p.CodigoSubFn==idMedioPago && p.CodigoFn==103);

            if (hist_fn == null)
            {
                return NotFound();
            }

            return Ok(hist_fn);
        }

        // PUT: api/Hist_fnMediosPago/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHist_fn([FromRoute] int id, [FromBody] Hist_fn hist_fn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hist_fn.ID)
            {
                return BadRequest();
            }

            _context.Entry(hist_fn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Hist_fnExists(id))
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

        // POST: api/Hist_fnMediosPago
        [HttpPost]
        public async Task<IActionResult> PostHist_fn([FromBody] Hist_fn hist_fn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Hist_fn.Add(hist_fn);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHist_fn", new { id = hist_fn.ID }, hist_fn);
        }

        // DELETE: api/Hist_fnMediosPago/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHist_fn([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hist_fn = await _context.Hist_fn.FindAsync(id);
            if (hist_fn == null)
            {
                return NotFound();
            }

            _context.Hist_fn.Remove(hist_fn);
            await _context.SaveChangesAsync();

            return Ok(hist_fn);
        }

        private bool Hist_fnExists(int id)
        {
            return _context.Hist_fn.Any(e => e.ID == id);
        }
    }
}
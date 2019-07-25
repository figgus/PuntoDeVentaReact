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
    public class AnulacionesVentasController : ControllerBase
    {
        private readonly ContextoBDMysql _context;

        public AnulacionesVentasController()
        {
            _context = new ContextoBDMysql();
        }

        // GET: api/AnulacionesVentas
        [HttpGet]
        public IEnumerable<AnulacionesVentas> GetAnulacionesVentas()
        {
            return _context.AnulacionesVentas;
        }

        // GET: api/AnulacionesVentas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnulacionesVentas([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var anulacionesVentas = await _context.AnulacionesVentas.FindAsync(id);

            if (anulacionesVentas == null)
            {
                return NotFound();
            }

            return Ok(anulacionesVentas);
        }

        // PUT: api/AnulacionesVentas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnulacionesVentas([FromRoute] int id, [FromBody] AnulacionesVentas anulacionesVentas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != anulacionesVentas.ID)
            {
                return BadRequest();
            }

            _context.Entry(anulacionesVentas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnulacionesVentasExists(id))
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

        // POST: api/AnulacionesVentas
        [HttpPost]
        public async Task<IActionResult> PostAnulacionesVentas([FromBody] AnulacionesVentas anulacionesVentas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            anulacionesVentas.Fecha = DateTime.Now;
            _context.AnulacionesVentas.Add(anulacionesVentas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnulacionesVentas", new { id = anulacionesVentas.ID }, anulacionesVentas);
        }

        // DELETE: api/AnulacionesVentas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnulacionesVentas([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var anulacionesVentas = await _context.AnulacionesVentas.FindAsync(id);
            if (anulacionesVentas == null)
            {
                return NotFound();
            }

            _context.AnulacionesVentas.Remove(anulacionesVentas);
            await _context.SaveChangesAsync();

            return Ok(anulacionesVentas);
        }

        private bool AnulacionesVentasExists(int id)
        {
            return _context.AnulacionesVentas.Any(e => e.ID == id);
        }
    }
}
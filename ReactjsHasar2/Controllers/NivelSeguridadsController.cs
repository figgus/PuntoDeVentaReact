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
    public class NivelSeguridadsController : ControllerBase
    {
        private readonly ContextoBDMysql _context=new ContextoBDMysql();

       

        // GET: api/NivelSeguridads
        [HttpGet]
        public IEnumerable<NivelSeguridad> GetNivelSeguridad()
        {
            return _context.Nivel_Seguridad;
        }

        // GET: api/NivelSeguridads/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNivelSeguridad([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nivelSeguridad = await _context.Nivel_Seguridad.FindAsync(id);

            if (nivelSeguridad == null)
            {
                return NotFound();
            }

            return Ok(nivelSeguridad);
        }

        // PUT: api/NivelSeguridads/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNivelSeguridad([FromRoute] int id, [FromBody] NivelSeguridad nivelSeguridad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nivelSeguridad.NivelPermiso)
            {
                return BadRequest();
            }

            _context.Entry(nivelSeguridad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NivelSeguridadExists(id))
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

        // POST: api/NivelSeguridads
        [HttpPost]
        public async Task<IActionResult> PostNivelSeguridad([FromBody] NivelSeguridad nivelSeguridad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Nivel_Seguridad.Add(nivelSeguridad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNivelSeguridad", new { id = nivelSeguridad.NivelPermiso }, nivelSeguridad);
        }

        // DELETE: api/NivelSeguridads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNivelSeguridad([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nivelSeguridad = await _context.Nivel_Seguridad.FindAsync(id);
            if (nivelSeguridad == null)
            {
                return NotFound();
            }

            _context.Nivel_Seguridad.Remove(nivelSeguridad);
            await _context.SaveChangesAsync();

            return Ok(nivelSeguridad);
        }

        private bool NivelSeguridadExists(int id)
        {
            return _context.Nivel_Seguridad.Any(e => e.NivelPermiso == id);
        }
    }
}
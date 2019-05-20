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
    public class SolicitudsController : ControllerBase
    {
        private readonly ContextoBDMysql _context=new ContextoBDMysql();

        

        // GET: api/Solicituds
        [HttpGet]
        public IEnumerable<Solicitud> GetSolicitud()
        {
            return _context.Solicitud;
        }

        // GET: api/Solicituds/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSolicitud([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var solicitud = await _context.Solicitud.FindAsync(id);

            if (solicitud == null)
            {
                return NotFound();
            }

            return Ok(solicitud);
        }

        // PUT: api/Solicituds/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSolicitud([FromRoute] int id, [FromBody] Solicitud solicitud)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != solicitud.ID)
            {
                return BadRequest();
            }

            _context.Entry(solicitud).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SolicitudExists(id))
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

        // POST: api/Solicituds
        [HttpPost]
        public async Task<IActionResult> PostSolicitud([FromBody] Solicitud solicitud)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Solicitud.Add(solicitud);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSolicitud", new { id = solicitud.ID }, solicitud);
        }

        // DELETE: api/Solicituds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSolicitud([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var solicitud = await _context.Solicitud.FindAsync(id);
            if (solicitud == null)
            {
                return NotFound();
            }

            _context.Solicitud.Remove(solicitud);
            await _context.SaveChangesAsync();

            return Ok(solicitud);
        }

        private bool SolicitudExists(int id)
        {
            return _context.Solicitud.Any(e => e.ID == id);
        }
    }
}
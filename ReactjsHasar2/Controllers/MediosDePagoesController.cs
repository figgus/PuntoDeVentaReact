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
    public class MediosDePagoesController : ControllerBase
    {
        private readonly ContextoBDMysql _context;

        public MediosDePagoesController()
        {
            _context = new ContextoBDMysql();
        }

        // GET: api/MediosDePagoes
        [HttpGet]
        public IEnumerable<MediosDePago> GetMediosDePago()
        {
            return _context.MediosDePago;
        }

        // GET: api/MediosDePagoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMediosDePago([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mediosDePago = await _context.MediosDePago.FindAsync(id);

            if (mediosDePago == null)
            {
                return NotFound();
            }

            return Ok(mediosDePago);
        }

        // PUT: api/MediosDePagoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMediosDePago([FromRoute] int id, [FromBody] MediosDePago mediosDePago)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mediosDePago.ID)
            {
                return BadRequest();
            }

            _context.Entry(mediosDePago).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MediosDePagoExists(id))
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

        // POST: api/MediosDePagoes
        [HttpPost]
        public async Task<IActionResult> PostMediosDePago([FromBody] MediosDePago mediosDePago)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MediosDePago.Add(mediosDePago);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMediosDePago", new { id = mediosDePago.ID }, mediosDePago);
        }

        // DELETE: api/MediosDePagoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMediosDePago([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mediosDePago = await _context.MediosDePago.FindAsync(id);
            if (mediosDePago == null)
            {
                return NotFound();
            }

            _context.MediosDePago.Remove(mediosDePago);
            await _context.SaveChangesAsync();

            return Ok(mediosDePago);
        }

        private bool MediosDePagoExists(int id)
        {
            return _context.MediosDePago.Any(e => e.ID == id);
        }
    }
}
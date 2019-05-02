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
    public class ZetasController : ControllerBase
    {
        private readonly ContextoBDMysql _context=new ContextoBDMysql();

     

        // GET: api/Zetas
        [HttpGet]
        public IEnumerable<Zeta> GetZeta()
        {
            return _context.Zeta;
        }

        // GET: api/Zetas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetZeta([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var zeta = await _context.Zeta.FindAsync(id);

            if (zeta == null)
            {
                return NotFound();
            }

            return Ok(zeta);
        }

        // PUT: api/Zetas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZeta([FromRoute] int id, [FromBody] Zeta zeta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != zeta.NroZeta)
            {
                return BadRequest();
            }

            _context.Entry(zeta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZetaExists(id))
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

        // POST: api/Zetas
        [HttpPost]
        public async Task<IActionResult> PostZeta([FromBody] Zeta zeta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Zeta.Add(zeta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetZeta", new { id = zeta.NroZeta }, zeta);
        }

        // DELETE: api/Zetas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZeta([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var zeta = await _context.Zeta.FindAsync(id);
            if (zeta == null)
            {
                return NotFound();
            }

            _context.Zeta.Remove(zeta);
            await _context.SaveChangesAsync();

            return Ok(zeta);
        }

        private bool ZetaExists(int id)
        {
            return _context.Zeta.Any(e => e.NroZeta == id);
        }
    }
}
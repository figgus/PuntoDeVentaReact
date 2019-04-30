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
    public class pluController : ControllerBase
    {
        private readonly ContextoBDMysql _context=new ContextoBDMysql();

       

        // GET: api/plu
        [HttpGet]
        public IEnumerable<plu> Getplu()
        {
            return _context.plu;
        }

        // GET: api/plu/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getplu([FromRoute] Int64 id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var plu = await _context.plu.Where(p=>p.CodigoScanner==id.ToString()).FirstOrDefaultAsync();

            if (plu == null)
            {
                return NotFound();
            }

            return Ok(plu);
        }

        // PUT: api/plu/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putplu([FromRoute] int id, [FromBody] plu plu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != plu.CodigoPLU)
            {
                return BadRequest();
            }

            _context.Entry(plu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!pluExists(id))
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

        // POST: api/plu
        [HttpPost]
        public async Task<IActionResult> Postplu([FromBody] plu plu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.plu.Add(plu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getplu", new { id = plu.CodigoPLU }, plu);
        }

        // DELETE: api/plu/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteplu([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var plu = await _context.plu.FindAsync(id);
            if (plu == null)
            {
                return NotFound();
            }

            _context.plu.Remove(plu);
            await _context.SaveChangesAsync();

            return Ok(plu);
        }

        private bool pluExists(int id)
        {
            return _context.plu.Any(e => e.CodigoPLU == id);
        }
    }
}
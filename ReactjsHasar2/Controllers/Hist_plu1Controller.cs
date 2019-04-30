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
    public class Hist_plu1Controller : ControllerBase
    {
        private readonly ContextoBDMysql _context=new ContextoBDMysql();

        

        // GET: api/Hist_plu1
        [HttpGet]
        public IEnumerable<Hist_plu> GetHist_plu()
        {
            return _context.Hist_plu;
        }

        // GET: api/Hist_plu1/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHist_plu([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hist_plu = await _context.Hist_plu.FindAsync(id);

            if (hist_plu == null)
            {
                return NotFound();
            }

            return Ok(hist_plu);
        }

        // PUT: api/Hist_plu1/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHist_plu([FromRoute] int id, [FromBody] Hist_plu hist_plu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hist_plu.ID)
            {
                return BadRequest();
            }

            _context.Entry(hist_plu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Hist_pluExists(id))
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

        // POST: api/Hist_plu1
        [HttpPost]
        public async Task<IActionResult> PostHist_plu([FromBody] Hist_plu hist_plu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Hist_plu.Add(hist_plu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHist_plu", new { id = hist_plu.ID }, hist_plu);
        }

        // DELETE: api/Hist_plu1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHist_plu([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hist_plu = await _context.Hist_plu.FindAsync(id);
            if (hist_plu == null)
            {
                return NotFound();
            }

            _context.Hist_plu.Remove(hist_plu);
            await _context.SaveChangesAsync();

            return Ok(hist_plu);
        }

        private bool Hist_pluExists(int id)
        {
            return _context.Hist_plu.Any(e => e.ID == id);
        }
    }
}
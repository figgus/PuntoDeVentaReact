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
    public class AjustesController : ControllerBase
    {
        private readonly ContextoBDMysql _context=new ContextoBDMysql();

        

        // GET: api/Ajustes
        [HttpGet]
        public IEnumerable<Ajustes> GetAjustes()
        {
            return _context.Ajustes;
        }

        // GET: api/Ajustes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAjustes([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ajustes = await _context.Ajustes.FindAsync(id);

            if (ajustes == null)
            {
                return NotFound();
            }

            return Ok(ajustes);
        }

        // PUT: api/Ajustes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAjustes([FromRoute] int id, [FromBody] Ajustes ajustes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ajustes.ID)
            {
                return BadRequest();
            }

            _context.Entry(ajustes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AjustesExists(id))
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

        // POST: api/Ajustes
        [HttpPost]
        public async Task<IActionResult> PostAjustes([FromBody] Ajustes ajustes)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_context.Ajustes.ToList().Count>0)
            {
                _context.Database.ExecuteSqlCommand("delete from Ajustes");
            }
            _context.Ajustes.Add(ajustes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAjustes", new { id = ajustes.ID }, ajustes);
        }

        // DELETE: api/Ajustes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAjustes([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ajustes = await _context.Ajustes.FindAsync(id);
            if (ajustes == null)
            {
                return NotFound();
            }

            _context.Ajustes.Remove(ajustes);
            await _context.SaveChangesAsync();

            return Ok(ajustes);
        }

        private bool AjustesExists(int id)
        {
            return _context.Ajustes.Any(e => e.ID == id);
        }
    }
}
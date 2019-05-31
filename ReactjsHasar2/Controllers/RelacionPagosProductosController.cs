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
    public class RelacionPagosProductosController : ControllerBase
    {
        private readonly ContextoBDMysql _context;

        public RelacionPagosProductosController()
        {
            _context = new ContextoBDMysql();
        }

        // GET: api/RelacionPagosProductos
        [HttpGet]
        public IEnumerable<RelacionPagosProducto> GetRelacionPagosProductos()
        {
            return _context.RelacionPagosProducto;
        }

        // GET: api/RelacionPagosProductos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRelacionPagosProductos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var relacionPagosProductos = await _context.RelacionPagosProducto.FindAsync(id);

            if (relacionPagosProductos == null)
            {
                return NotFound();
            }

            return Ok(relacionPagosProductos);
        }

        // PUT: api/RelacionPagosProductos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRelacionPagosProductos([FromRoute] int id, [FromBody] RelacionPagosProducto relacionPagosProductos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != relacionPagosProductos.ID)
            {
                return BadRequest();
            }

            _context.Entry(relacionPagosProductos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RelacionPagosProductosExists(id))
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

        // POST: api/RelacionPagosProductos
        [HttpPost]
        public async Task<IActionResult> PostRelacionPagosProductos([FromBody] RelacionPagosProducto relacionPagosProductos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RelacionPagosProducto.Add(relacionPagosProductos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRelacionPagosProductos", new { id = relacionPagosProductos.ID }, relacionPagosProductos);
        }

        // DELETE: api/RelacionPagosProductos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRelacionPagosProductos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var relacionPagosProductos = await _context.RelacionPagosProducto.FindAsync(id);
            if (relacionPagosProductos == null)
            {
                return NotFound();
            }

            _context.RelacionPagosProducto.Remove(relacionPagosProductos);
            await _context.SaveChangesAsync();

            return Ok(relacionPagosProductos);
        }

        private bool RelacionPagosProductosExists(int id)
        {
            return _context.RelacionPagosProducto.Any(e => e.ID == id);
        }
    }
}
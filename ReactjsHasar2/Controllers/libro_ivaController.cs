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
    public class libro_ivaController : ControllerBase
    {
        private readonly ContextoBDMysql _context=new ContextoBDMysql();

        

        // GET: api/libro_iva
        [HttpGet]
        public IEnumerable<libro_iva> Getlibro_iva()
        {
            
            return _context.libro_iva;
        }

        // GET: api/libro_iva/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getlibro_iva([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var libro_iva = await _context.libro_iva.FindAsync(id);

            if (libro_iva == null)
            {
                return NotFound();
            }

            return Ok(libro_iva);
        }

        // PUT: api/libro_iva/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putlibro_iva([FromRoute] int id, [FromBody] libro_iva libro_iva)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != libro_iva.ID)
            {
                return BadRequest();
            }

            _context.Entry(libro_iva).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!libro_ivaExists(id))
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

        // POST: api/libro_iva
        [HttpPost]
        public async Task<IActionResult> Postlibro_iva([FromBody] libro_iva libro_iva)
        {
            libro_iva.TipoComprobante = "CFB";
            libro_iva.RazonSocial = "Consumidor Final";
            libro_iva.NetoGravado = libro_iva.TotalOperacion * 0.81;
            libro_iva.NumeroComprobante = "123456";
            libro_iva.Fecha = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.libro_iva.Add(libro_iva);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getlibro_iva", new { id = libro_iva.ID }, libro_iva);
        }

        // DELETE: api/libro_iva/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletelibro_iva([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var libro_iva = await _context.libro_iva.FindAsync(id);
            if (libro_iva == null)
            {
                return NotFound();
            }

            _context.libro_iva.Remove(libro_iva);
            await _context.SaveChangesAsync();

            return Ok(libro_iva);
        }

        private bool libro_ivaExists(int id)
        {
            return _context.libro_iva.Any(e => e.ID == id);
        }
    }
}
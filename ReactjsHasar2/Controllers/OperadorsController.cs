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
    public class OperadorsController : ControllerBase
    {
        private readonly ContextoBDMysql _context=new ContextoBDMysql();

       

        // GET: api/Operadors
        [HttpGet]
        public IEnumerable<Operador> GetOperador()
        {
            return _context.Operador;
        }

        // GET: api/Operadors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOperador([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var operador = await _context.Operador.FindAsync(id);

            if (operador == null)
            {
                return NotFound();
            }

            return Ok(operador);
        }

        // PUT: api/Operadors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOperador([FromRoute] int id, [FromBody] Operador operador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != operador.CodigoOperador)
            {
                return BadRequest();
            }

            _context.Entry(operador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperadorExists(id))
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

        // POST: api/Operadors
        [HttpPost]
        public async Task<IActionResult> PostOperador([FromBody] Operador operador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Operador.Add(operador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOperador", new { id = operador.CodigoOperador }, operador);
        }

        // DELETE: api/Operadors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOperador([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var operador = await _context.Operador.FindAsync(id);
            if (operador == null)
            {
                return NotFound();
            }

            _context.Operador.Remove(operador);
            await _context.SaveChangesAsync();

            return Ok(operador);
        }

        private bool OperadorExists(int id)
        {
            return _context.Operador.Any(e => e.CodigoOperador == id);
        }
    }
}
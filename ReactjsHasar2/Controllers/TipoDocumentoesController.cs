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
    public class TipoDocumentoesController : ControllerBase
    {
        private readonly ContextoBDMysql _context=new ContextoBDMysql();

        

        // GET: api/TipoDocumentoes
        [HttpGet]
        public IEnumerable<TipoDocumento> GetTipoDocumento()
        {
            return _context.Tipo_Documento;
        }

        // GET: api/TipoDocumentoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipoDocumento([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipoDocumento = await _context.Tipo_Documento.FindAsync(id);

            if (tipoDocumento == null)
            {
                return NotFound();
            }

            return Ok(tipoDocumento);
        }

        // PUT: api/TipoDocumentoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoDocumento([FromRoute] int id, [FromBody] TipoDocumento tipoDocumento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoDocumento.ID)
            {
                return BadRequest();
            }

            _context.Entry(tipoDocumento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoDocumentoExists(id))
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

        // POST: api/TipoDocumentoes
        [HttpPost]
        public async Task<IActionResult> PostTipoDocumento([FromBody] TipoDocumento tipoDocumento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Tipo_Documento.Add(tipoDocumento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoDocumento", new { id = tipoDocumento.ID }, tipoDocumento);
        }

        // DELETE: api/TipoDocumentoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoDocumento([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipoDocumento = await _context.Tipo_Documento.FindAsync(id);
            if (tipoDocumento == null)
            {
                return NotFound();
            }

            _context.Tipo_Documento.Remove(tipoDocumento);
            await _context.SaveChangesAsync();

            return Ok(tipoDocumento);
        }

        private bool TipoDocumentoExists(int id)
        {
            return _context.Tipo_Documento.Any(e => e.ID == id);
        }
    }
}
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
    public class FoliosLocalsController : ControllerBase
    {
        private readonly ContextoBDMysql _context=new ContextoBDMysql();

        

        // GET: api/FoliosLocals
        [HttpGet]
        public IEnumerable<FoliosLocal> GetFoliosLocal()
        {
            return _context.FoliosLocal;
        }

        // GET: api/FoliosLocals/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFoliosLocal([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var foliosLocal = await _context.FoliosLocal.FindAsync(id);

            if (foliosLocal == null)
            {
                return NotFound();
            }

            return Ok(foliosLocal);
        }

        // PUT: api/FoliosLocals/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoliosLocal([FromRoute] int id, [FromBody] FoliosLocal foliosLocal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != foliosLocal.ID)
            {
                return BadRequest();
            }

            _context.Entry(foliosLocal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoliosLocalExists(id))
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

        // POST: api/FoliosLocals
        [HttpPost]
        public async Task<IActionResult> PostFoliosLocal([FromBody] FoliosLocal foliosLocal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            foliosLocal.fechaAsignacion = DateTime.Now;

            _context.FoliosLocal.Add(foliosLocal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFoliosLocal", new { id = foliosLocal.ID }, foliosLocal);
        }

        // DELETE: api/FoliosLocals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoliosLocal([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var foliosLocal = await _context.FoliosLocal.FindAsync(id);
            if (foliosLocal == null)
            {
                return NotFound();
            }

            _context.FoliosLocal.Remove(foliosLocal);
            await _context.SaveChangesAsync();

            return Ok(foliosLocal);
        }

        [Route("UsarFolio")]
        [HttpPost]
        public ActionResult UsarFolio()
        {
            bool folioDisponible = _context.FoliosLocal.Count(p=>p.estaDisponible==1)>0;
            if (!folioDisponible)
            {
                return BadRequest(new { mensaje="No hay folios disponibles"});
            }
            int folioDisp = getFolioAsignable();
            var FolioEditar = _context.FoliosLocal.FirstOrDefault(p=>p.numFolio==folioDisp);
            FolioEditar.estaDisponible = 0;
            FolioEditar.fechaAsignacion = DateTime.Now;
            _context.SaveChanges();
            return Ok(new {FolioUsado= folioDisp});
        }

        private int getFolioAsignable()
        {
            int res = 0;
            res = _context.FoliosLocal.Where(p=>p.estaDisponible==1).Min(p=>p.numFolio);

            return res;

        }

        private bool FoliosLocalExists(int id)
        {
            return _context.FoliosLocal.Any(e => e.ID == id);
        }
    }
}
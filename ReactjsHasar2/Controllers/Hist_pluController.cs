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
    public class Hist_pluController : ControllerBase
    {
        private readonly ContextoBDMysql _context = new ContextoBDMysql();

       

        // GET: api/Hist_plu
        [HttpGet]
        public ActionResult GetHist_plu()
        {
            return Ok(_context.Hist_plu.ToList());
        }

        // GET: api/Hist_plu/5
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

        // PUT: api/Hist_plu/5
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

        // POST: api/Hist_plu
        [HttpPost]
        public async Task<IActionResult> PostHist_plu([FromBody] Hist_plu hist_plu)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if (_context.Hist_plu.Where(p=>p.CodigoPLU== hist_plu.CodigoPLU).Count()>=1)//si ya se guardo el mismo producto
            //{
            //    //se añade 1 la cantidad y el precio pero no se guarda el objeto entero
            //    var prodModificar = _context.Hist_plu.FirstOrDefault(r=>r.CodigoPLU==hist_plu.CodigoPLU);
            //    prodModificar.Cantidad = prodModificar.Cantidad + 1;
            //    prodModificar.Monto = prodModificar.Monto + hist_plu.Monto;
            //    _context.SaveChanges();
            //}
            hist_plu.Fecha = DateTime.Now;
            hist_plu.NroPos = 0;
            hist_plu.MontoIVA = hist_plu.Monto * 0.19;
            hist_plu.Cantidad = 1;
            hist_plu.PorcIVA = 19;
            _context.Hist_plu.Add(hist_plu);
            await _context.SaveChangesAsync();



            return CreatedAtAction("GetHist_plu", new { id = hist_plu.ID }, hist_plu);
        }

        

        // DELETE: api/Hist_plu/5
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
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

            if (id != zeta.ID)
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
            //crea nueva zeta - pasa todas las ventas asociadas a ella la tabla hist_fn y vacia la tabla hist_plu
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            zeta.Fecha = DateTime.Now;
            zeta.NroZeta=_context.Zeta.Max(p=>p.NroZeta)+1;
            _context.Zeta.Add(zeta);

            await _context.SaveChangesAsync();
            var ventasDia = _context.Hist_plu;
            foreach (Hist_plu venta in ventasDia)
            {
                _context.Hist_fn.Add(new Hist_fn { NroPOS = venta.NroPos,
                    NroZeta =zeta.NroZeta,
                    Fecha =DateTime.Now,
                    CodigoFn =102,
                    CodigoSubFn =_context.plu.FirstOrDefault(p=>p.CodigoPLU==venta.CodigoPLU).CodigoSeccion,
                    Monto=venta.Monto,
                    PorcIVA=19,
                    Cantidad=venta.Cantidad,
                    FechaUltAct=DateTime.Now.ToLongDateString(),
                    MontoIVA=venta.Monto*0.19,
                    CodigoOperador=9999
                });
            }
            _context.SaveChanges();
            _context.Database.ExecuteSqlCommand("truncate table hist_plu");
            return CreatedAtAction("GetZeta", new { id = zeta.ID }, zeta);
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
            return _context.Zeta.Any(e => e.ID == id);
        }


    }
}
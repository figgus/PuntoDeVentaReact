﻿using System;
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
    public class SubfuncionsMediosPagoController : ControllerBase
    {
        private readonly ContextoBDMysql _context=new ContextoBDMysql();

        

        // GET: api/SubfuncionsMediosPago
        [HttpGet]
        public IEnumerable<Subfuncion> Getsubfuncion()
        {
            return _context.subfuncion.Where(p=>p.CodigoFn==103);
        }

        // GET: api/SubfuncionsMediosPago/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubfuncion([FromRoute] int id)//trae un medio de pago por su id
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subfuncion = await _context.subfuncion.FirstOrDefaultAsync(p => p.CodigoFn == 103 & p.CodigoSubFn==id);

            if (subfuncion == null)
            {
                return NotFound();
            }

            return Ok(subfuncion);
        }

        // PUT: api/SubfuncionsMediosPago/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubfuncion([FromRoute] int id, [FromBody] Subfuncion subfuncion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subfuncion.ID)
            {
                return BadRequest();
            }

            _context.Entry(subfuncion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubfuncionExists(id))
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

        // POST: api/SubfuncionsMediosPago
        [HttpPost]
        public async Task<IActionResult> PostSubfuncion([FromBody] Subfuncion subfuncion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.subfuncion.Add(subfuncion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubfuncion", new { id = subfuncion.ID }, subfuncion);
        }

        // DELETE: api/SubfuncionsMediosPago/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubfuncion([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subfuncion = await _context.subfuncion.FindAsync(id);
            if (subfuncion == null)
            {
                return NotFound();
            }

            _context.subfuncion.Remove(subfuncion);
            await _context.SaveChangesAsync();

            return Ok(subfuncion);
        }

        private bool SubfuncionExists(int id)
        {
            return _context.subfuncion.Any(e => e.ID == id);
        }
    }
}
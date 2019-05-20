using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactjsHasar2.DAL;

namespace ReactjsHasar2.Controllers
{
    [ApiController]
    public class OperacionesFoliosLocalesController : ControllerBase
    {

        private readonly ContextoBDMysql _context = new ContextoBDMysql();


        [Route("getTotales")]
        [HttpGet]
        public ActionResult getTotales()
        {
            return Ok(new { total = _context.FoliosLocal.Count() });
        }

        [Route("getRestantes")]
        [HttpGet]
        public ActionResult getRestantes()
        {
            return Ok(new { restantes = _context.FoliosLocal.Count(p => p.estaDisponible == 1) });
        }

        [Route("getUltimoAsignado")]
        [HttpGet]
        public ActionResult getUltimoAsignado()
        {
            var res = _context.FoliosLocal.Where(p => p.estaDisponible == 0).ToList();
            if (res.Count == 0)
            {
                return Ok(new { ultimoAsignado = 0 });
            }

            int ultimoAsignado = res.Max(p => p.ID);
            var ultimoFolioAsignado = _context.FoliosLocal.FirstOrDefault(p => p.ID == ultimoAsignado);

            return Ok(new { ultimoAsignado = ultimoFolioAsignado.numFolio });
        }

        [Route("vender")]
        [HttpPost]
        public ActionResult vender()
        {
            bool disponible = _context.FoliosLocal.Count(p => p.estaDisponible == 1) > 0;
            if (disponible)
            {


                int folioVenta = FoliominimoDisponible();
                var folioEditar = _context.FoliosLocal.FirstOrDefault(p => p.ID == folioVenta);
                folioEditar.estaDisponible = 0;
                folioEditar.fechaVenta = DateTime.Now;
                _context.SaveChangesAsync();
                return Ok();
            }
            return NotFound();
        }

        [Route("getNumeroVentas")]
        [HttpGet]
        public ActionResult getNumeroVentas()
        {
            return Ok(new { numVentas = _context.FoliosLocal.Count(p => p.estaDisponible == 0) });
        }

        [Route("getFoliosDia")]
        [HttpGet]
        public ActionResult getFoliosDia()
        {
            DateTime today = DateTime.Now.Date;
            var foliosDia = _context.FoliosLocal.Where(p => p.fechaAsignacion == today & p.estaDisponible == 0).ToList();

            return Ok(foliosDia);
        }

        [Route("getFoliosAyer")]
        [HttpGet]
        public ActionResult getFoliosAyer()
        {
            DateTime today = DateTime.Now.Date;
            DateTime ayer = today.AddDays(-1);
            var foliosDia = _context.FoliosLocal.Where(p => p.fechaAsignacion == today.AddDays(-1) & p.estaDisponible == 0).ToList();

            return Ok(foliosDia);
        }


        private int FoliominimoDisponible()
        {
            int res = _context.FoliosLocal.Where(p => p.estaDisponible == 1).Min(p => p.ID);
            return res;
        }

    }
}
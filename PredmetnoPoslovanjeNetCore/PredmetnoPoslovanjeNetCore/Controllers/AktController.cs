using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PredmetnoPoslovanjeNetCore.Models;
using PredmetnoPoslovanjeNetCore.PredmetData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PredmetnoPoslovanjeNetCore.Controllers
{
    [ApiController]
    public class AktController : ControllerBase
    {
        private IAktData _aktData;

        public AktController(IAktData aktData)
        {
            _aktData = aktData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetAkts()
        {
            return Ok(_aktData.GetAkts()); // dobijam nazad kao HTTP_OK
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetAkt(int id)
        {
            var akt = _aktData.GetAkt(id);

            if (akt != null)
            {
                return Ok(_aktData.GetAkt(id)); // dobijam nazad kao HTTP_OK
            }
            return NotFound("Akt with Id: {id} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddAkt(Akt akt)
        {
            _aktData.AddAkt(akt);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + akt.IdAkta,
                akt);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteAkt(int id)
        {
            var akt = _aktData.GetAkt(id);

            if (akt != null)
            {
                _aktData.DeleteAkt(akt);
                return Ok();
            }
            return NotFound("Akt with Id: {id} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditAkt(int id, Akt akt)
        {
            var existingAkt = _aktData.GetAkt(id);

            if (existingAkt != null)
            {
                akt.IdAkta = existingAkt.IdAkta;
                _aktData.EditAkt(akt);
            }

            return Ok(akt);
        }
    }
}

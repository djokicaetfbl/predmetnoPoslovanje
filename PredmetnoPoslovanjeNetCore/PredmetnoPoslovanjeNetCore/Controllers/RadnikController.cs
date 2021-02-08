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
    public class RadnikController : ControllerBase
    {
        private IRadnikData _radnikData;

        public RadnikController(IRadnikData aktData)
        {
            _radnikData = aktData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetRadniks()
        {
            return Ok(_radnikData.GetRadniks()); // dobijam nazad kao HTTP_OK
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetRadnik(int id)
        {
            var radnik = _radnikData.GetRadnik(id);

            if (radnik != null)
            {
                return Ok(_radnikData.GetRadnik(id)); // dobijam nazad kao HTTP_OK
            }
            return NotFound("Radnik with Id: {id} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddRadnik(Radnik radnik)
        {
            _radnikData.AddRadnik(radnik);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + radnik.IdRadnika,
                radnik);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteRadnik(int id)
        {
            var radnik = _radnikData.GetRadnik(id);

            if (radnik != null)
            {
                _radnikData.DeleteRadnik(radnik);
                return Ok();
            }
            return NotFound("Radnik with Id: {id} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditRadnik(int id, Radnik radnik)
        {
            var existingRadnik = _radnikData.GetRadnik(id);

            if (existingRadnik != null)
            {
                radnik.IdRadnika = existingRadnik.IdRadnika;
                _radnikData.EditRadnik(radnik);
            }

            return Ok(radnik);
        }
    }
}

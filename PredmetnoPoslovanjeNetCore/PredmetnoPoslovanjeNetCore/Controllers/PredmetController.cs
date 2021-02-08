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
    public class PredmetController : ControllerBase
    {
        private IPredmetData _predmetData;

        public PredmetController(IPredmetData predmetData)
        {
            _predmetData = predmetData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetPredmets()
        {
            return Ok(_predmetData.GetPredmets()); // dobijam nazad kao HTTP_OK
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetPredmet(int id)
        {
            var predmet = _predmetData.GetPredmet(id);

            if (predmet != null)
            {
                return Ok(_predmetData.GetPredmet(id)); // dobijam nazad kao HTTP_OK
            }
            return NotFound("Predmet with Id: {id} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddPredmet(Predmet predmet)
        {
            _predmetData.AddPredmet(predmet);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + predmet.IdPredmeta,
                predmet);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeletePredmet(int id)
        {
            var predmet = _predmetData.GetPredmet(id);

            if (predmet != null)
            {
                _predmetData.DeletePredmet(predmet);
                return Ok();
            }
            return NotFound("Predmet with Id: {id} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditPredmet(int id, Predmet predmet)
        {
            var existingPredmet = _predmetData.GetPredmet(id);

            if (existingPredmet != null)
            {
                predmet.IdPredmeta = existingPredmet.IdPredmeta;
                _predmetData.EditPredmet(predmet);
            }

            return Ok(predmet);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RaccoonMobile.Models;
using RaccoonMobile.Services;

namespace RaccoonMobile.Controllers
{
    [Route("fallas")]
    public class FallasController : Controller
    {
        private readonly IFalloServicio _fallosDeServicio;

        public FallasController(IFalloServicio fallosDeServicio)
        {
            this._fallosDeServicio = fallosDeServicio;
        }

        [HttpGet]
        [Route("GetFallos")]
        public IActionResult GetFallos()
        {
            if (_fallosDeServicio.ObtenerFallos().Count > 0)
            {
                return Json(_fallosDeServicio.ObtenerFallos());
            }
            else
            {
                return Json(new { message = "No hay fallos reportados" });
            }
        }

        [HttpGet]
        [Route("GetFallos/{id}")]
        public IActionResult GetFallos(int id)
        {
            if (_fallosDeServicio.ObtenerFallo(id) != null)
            {
                return Json(_fallosDeServicio.ObtenerFallo(id));
            }
            else
            {
                return Json(new { message = "Fallo no encontrado" });
            }
        }

        [HttpPost]
        [Route("PostFallo")]
        public IActionResult PostFallo([FromBody] Fallo falloBody)
        {
            Fallo? fallo = _fallosDeServicio.ReportarFallo(falloBody);
            if (fallo != null)
            {
                return Json(new { message = $"Fallo reportado con id {fallo.id}" });
            }
            else
            {
                return Json(new { message = "Error" });
            }
        }

        [HttpPut]
        [Route("UpdateFallo")]
        public IActionResult UpdateFallo([FromBody] Fallo fallo)
        {
            if (_fallosDeServicio.ActualizarFallo(fallo))
            {
                return Json(new { message = "Fallo actualizado" });
            }
            else
            {
                return Json(new { message = "Fallo no encontrado" });
            }
        }

        [HttpDelete]
        [Route("DeleteFallo/{id}")]
        public IActionResult DeleteFallo(int id)
        {
            if (_fallosDeServicio.EliminarFallo(id))
            {
                return Json(new { message = "Fallo eliminado" });
            }
            else
            {
                return Json(new { message = "Fallo no encontrado" });
            }
        }

        public IActionResult User()
        {
            return View();
        }
    }
}
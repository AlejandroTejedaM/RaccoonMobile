using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RaccoonMobile.Models;
using RaccoonMobile.Services;
using Microsoft.AspNetCore.SignalR;
using RaccoonMobile.Hubs;

namespace RaccoonMobile.Controllers
{
    [Route("fallas")]
    public class FallasController : Controller
    {
        private readonly IFalloServicio _fallosDeServicio;
        private readonly IHubContext<NotificacionesHub> _hubContext;

        public FallasController(IFalloServicio fallosDeServicio, IHubContext<NotificacionesHub> hubContext)
        {
            _fallosDeServicio = fallosDeServicio;
            _hubContext = hubContext;
        }

        [HttpGet]
        [Route("GetFallos")]
        public async Task<IActionResult> GetFallos()
        {
            var fallos = await Task.Run(() => _fallosDeServicio.ObtenerFallos());
            if (fallos.Count > 0)
            {
                return Json(fallos);
            }
            else
            {
                return Json(new { message = "No hay fallos reportados" });
            }
        }

        [HttpGet]
        [Route("GetFallos/{id}")]
        public async Task<IActionResult> GetFallos(int id)
        {
            var fallo = await Task.Run(() => _fallosDeServicio.ObtenerFallo(id));
            if (fallo != null)
            {
                return Json(fallo);
            }
            else
            {
                return Json(new { message = "Fallo no encontrado" });
            }
        }

        [HttpPost]
        [Route("PostFallo")]
        public async Task<IActionResult> PostFallo([FromBody] Fallo falloBody)
        {
            var fallo = await Task.Run(() => _fallosDeServicio.ReportarFallo(falloBody));
            if (fallo != null)
            {
                await _hubContext.Clients.All.SendAsync("NuevoFalloReportado", $"Nuevo fallo reportado con id {fallo.id}");
                return Json(new { message = $"Fallo reportado con id {fallo.id}" });
            }
            else
            {
                return Json(new { message = "Error al reportar el fallo" });
            }
        }

        [HttpPut]
        [Route("UpdateFallo")]
        public async Task<IActionResult> UpdateFallo([FromBody] Fallo fallo)
        {
            var resultado = await Task.Run(() => _fallosDeServicio.ActualizarFallo(fallo));
            if (resultado)
            {
                await _hubContext.Clients.All.SendAsync("FalloActualizado", $"Fallo actualizado: {fallo.id}");
                return Json(new { message = "Fallo actualizado" });
            }
            else
            {
                return Json(new { message = "Fallo no encontrado" });
            }
        }

        [HttpDelete]
        [Route("DeleteFallo/{id}")]
        public async Task<IActionResult> DeleteFallo(int id)
        {
            var resultado = await Task.Run(() => _fallosDeServicio.EliminarFallo(id));
            if (resultado)
            {
                await _hubContext.Clients.All.SendAsync("FalloActualizado", $"Fallo eliminado: {id}");
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

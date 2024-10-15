using Microsoft.AspNetCore.Mvc;
using RaccoonMobile.Services;

namespace RaccoonMobile.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: UsuarioController
        private readonly IUsuarioServicio _usuarioServicio;
        public ActionResult Index()
        {
            return View();
        }

    }
}

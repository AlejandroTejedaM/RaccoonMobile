using Microsoft.AspNetCore.Mvc;

namespace RaccoonMobile.Views.Encargado;

public class EncargadoController : Controller
{
    public IActionResult Home()
    {
        return View();
    }
}
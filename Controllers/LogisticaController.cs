using Microsoft.AspNetCore.Mvc;

namespace RaccoonMobile.Controllers;

public class LogisticaController : Controller
{
    // GET
    public IActionResult IndexLogistica()
    {
        return View();
    }
}
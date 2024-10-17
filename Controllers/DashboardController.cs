using Microsoft.AspNetCore.Mvc;

namespace RaccoonMobile.Controllers;

public class DashboardController : Controller
{
    public IActionResult IndexDashboard()
    {
        return View();
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProduktKatalog.Controllers
{
    [Authorize(Roles = "Admin")] // Endast användare med rollen "Admin" kan nå denna controller
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

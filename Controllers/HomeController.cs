using Microsoft.AspNetCore.Mvc;

namespace CRUDApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
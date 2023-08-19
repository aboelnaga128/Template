using Microsoft.AspNetCore.Mvc;

namespace Template.PL.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

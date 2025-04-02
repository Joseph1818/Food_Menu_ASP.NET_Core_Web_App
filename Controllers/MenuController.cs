using Microsoft.AspNetCore.Mvc;

namespace Menu.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

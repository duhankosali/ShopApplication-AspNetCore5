using Microsoft.AspNetCore.Mvc;

namespace ShopApplication.UI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

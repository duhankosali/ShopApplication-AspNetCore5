using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopApplication.Business.Abstract;
using ShopApplication.UI.Identity;

namespace ShopApplication.UI.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        // Dependency Injection
        private ICartService _cartService;
        private UserManager<ApplicationUser> _userManager;

        public CartController(ICartService cartService, UserManager<ApplicationUser> userManager)
        {
            _cartService = cartService;
            _userManager = userManager; 
        }

        public IActionResult Index()
        {
            string userId = _userManager.GetUserId(User); // ApplicationUser'ı kullanarak giriş yapmış olan kullanıcının ID verisini değişkene atadık.

            var cart = _cartService.GetCartByUserId(_userManager.GetUserId(User));

            System.Console.WriteLine(cart);

            return View();
        }

        [HttpPost] // Ekleme işlemi olduğu için PostMethod
        public IActionResult AddToCart()
        {
            return View();
        }
    }
}

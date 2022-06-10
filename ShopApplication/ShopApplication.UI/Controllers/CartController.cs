using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopApplication.Business.Abstract;
using ShopApplication.UI.Identity;
using ShopApplication.UI.Models;
using System.Linq;

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

            var cart = _cartService.GetCartByUserId(userId);

            return View(new CartModel()
            {
                CartId = cart.Id,
                CartItems = cart.CartItems.Select(i => new CartItemModel()
                {
                    CartItemId = i.Id,
                    ProductId = i.Product.Id,
                    Name = i.Product.Name,
                    Price = (decimal)i.Product.Price,
                    ImageUrl = i.Product.ImageUrl,
                    Quantity = i.Quantity
                }).ToList()
            });
        }

        [HttpPost] // Ekleme işlemi olduğu için PostMethod
        public IActionResult AddToCart(int productId, int quantity)
        {
            string userId = _userManager.GetUserId(User);

            _cartService.AddToCart(userId, productId, quantity);

            return RedirectToAction("Index");
        }

        [HttpPost]  
        public IActionResult DeleteFromCart(int productId)
        {
            string userId = _userManager.GetUserId(User);

            _cartService.DeleteFromCart(userId, productId);
            return RedirectToAction("Index");
        }

        public IActionResult Checkout()
        {
            var userId = _userManager.GetUserId(User);
            var cart = _cartService.GetCartByUserId(userId);

            var orderModel = new OrderModel();

            orderModel.CartModel = new CartModel()
            {
                CartId = cart.Id,
                CartItems = cart.CartItems.Select(i => new CartItemModel()
                {
                    CartItemId = i.Id,
                    ProductId = i.Product.Id,
                    Name = i.Product.Name,
                    Price = (decimal)i.Product.Price,
                    ImageUrl = i.Product.ImageUrl,
                    Quantity = i.Quantity
                }).ToList()
            };

            return View(orderModel);
        }

    }
}

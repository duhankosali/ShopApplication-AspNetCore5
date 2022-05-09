using Microsoft.AspNetCore.Mvc;
using ShopApplication.Business.Abstract;
using ShopApplication.Entities;
using ShopApplication.UI.Models;
using System.Linq;

namespace ShopApplication.UI.Controllers
{
    public class ShopController : Controller
    {
        // Dependency Injection
        private IProductService _productService;

        public ShopController(IProductService productService)
        {
            _productService = productService;
        }


        public IActionResult List()
        {
            return View(new ProductListModel()
            {
                Products = _productService.GetAll()
            });
        }

        public IActionResult Details(int? id)
        {
            if (id==null)
            {
                return NotFound(); // Kullanıcıya hata sayfasına götürür.
            }

            Product product = _productService.GetProductDetails((int)id); 

            if(product==null) // Gelen parametre ile uyuşan id 'de bir ürün var mı ? Yoksa Null, varsa döndür.
            {
                return NotFound();
            }

            return View(new ProductDetailsModel()
            {
                Product = product,
                Categories = product.ProductCategories.Select(i => i.Category).ToList()
            });
        }
    }
}

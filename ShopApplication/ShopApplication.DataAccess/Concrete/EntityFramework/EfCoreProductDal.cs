using Microsoft.EntityFrameworkCore;
using ShopApplication.DataAccess.Abstract;
using ShopApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.DataAccess.Concrete.EntityFramework
{
    public class EfCoreProductDal : EfCoreGenericRepository<Product, ShopContext>, IProductDal
    {
        // Ortak fonksiyonlar "EfCoreGenericRepository.cs dosyasında"
        public List<Product> GetProductsByCategory(string category, int page, int pageSize) // IProductDal'a özel olan method.
        {
            //throw new NotImplementedException();

            using (var context = new ShopContext())
            {
                var products = context.Products.AsQueryable();

                if (!string.IsNullOrEmpty(category)) // Eğer category bilgisi NULL değilse: 
                {
                    products = products
                        .Include(i => i.ProductCategories)
                        .ThenInclude(i => i.Category)
                        .Where(i => i.ProductCategories.Any(a=>a.Category.Name.ToLower() == category.ToLower()));
                }
                return products.Skip((page-1) * pageSize).Take(pageSize).ToList(); // Liste halinde döndürüyoruz. (Sayfalara ayırarak)
            }
        }

        public Product GetProductDetails(int id)
        {
            //throw new NotImplementedException();

            using (var context = new ShopContext())
            {
                return context.Products
                    .Where(p => p.Id == id)
                    .Include(p => p.ProductCategories)
                    .ThenInclude(p=>p.Category)
                    .FirstOrDefault(); // Tek bir değer döndürüyoruz.
            }
        }

        public int GetCountByCategory(string category)
        {
            using (var context = new ShopContext())
            {
                var products = context.Products.AsQueryable();

                if (!string.IsNullOrEmpty(category))
                {
                    products = products
                                .Include(i => i.ProductCategories)
                                .ThenInclude(i => i.Category)
                                .Where(i => i.ProductCategories.Any(a => a.Category.Name.ToLower() == category.ToLower()));
                }

                return products.Count();
            }
        }
    }
}

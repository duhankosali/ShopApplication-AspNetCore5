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
        public IEnumerable<Product> GetPopularProducts() // IProductDal'a özel olan method.
        {
            throw new NotImplementedException();
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
                    .FirstOrDefault();
            }
        }
    }
}

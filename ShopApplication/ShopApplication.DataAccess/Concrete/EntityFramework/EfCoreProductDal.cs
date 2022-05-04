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
    }
}

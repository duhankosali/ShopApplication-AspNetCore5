using ShopApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.DataAccess.Abstract
{
    public interface IProductDal : IRepository<Product> // Dal --> Data Access Layer, IProductRepository
    {
        // ProductDal'a ek olarak eklemek istediğimiz method olursa buraya ekleyeceğiz.
        IEnumerable<Product> GetPopularProducts();
        Product GetProductDetails(int id);
    }
}

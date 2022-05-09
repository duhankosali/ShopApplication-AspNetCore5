using ShopApplication.Business.Abstract;
using ShopApplication.DataAccess.Abstract;
using ShopApplication.DataAccess.Concrete.EntityFramework;
using ShopApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.Business.Concrete
{
    public class ProductManager : IProductService
    {
        //EfCoreProductDal _productDal = new EfCoreProductDal(); // Bunu kullanmam yanlış. Alt satırdaki gibi bir Injection işlemi yapmalıyım.

        private IProductDal _productDal; // DataAccess katmanına erişmek için Dependency Injection

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Create(Product entity)
        {
            _productDal.Create(entity);
        }

        public void Delete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public List<Product> GetAll()
        {
            //throw new NotImplementedException();

            return _productDal.GetAll();
        }

        public Product GetById(int id)
        {
            //throw new NotImplementedException();

            return _productDal.GeyById(id);
        }

        public List<Product> GetPopularProducts()
        {
            //throw new NotImplementedException();

            return _productDal.GetAll();
        }

        public Product GetProductDetails(int id)
        {
            //throw new NotImplementedException();
            return _productDal.GetProductDetails(id);
        }

        public void Update(Product entity)
        {
            //throw new NotImplementedException();
            _productDal.Update(entity);
        }
    }
}

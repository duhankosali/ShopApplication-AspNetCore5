using ShopApplication.Business.Abstract;
using ShopApplication.DataAccess.Abstract;
using ShopApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal; // DataAccess katmanına erişmek için Dependency Injection

        public CategoryManager(ICategoryDal categoryDal) // constructor
        {
            _categoryDal = categoryDal;
        }



        public void Create(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            //throw new NotImplementedException();

            return _categoryDal.GetAll();   
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}

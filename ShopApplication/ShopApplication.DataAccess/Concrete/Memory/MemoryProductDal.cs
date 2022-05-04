﻿using ShopApplication.DataAccess.Abstract;
using ShopApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.DataAccess.Concrete.Memory
{
    public class MemoryProductDal : IProductDal
    {
        public void Create(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            //throw new NotImplementedException();

            var products = new List<Product>()
            {
                new Product() { Id = 1, Name ="Samsung S6", ImageUrl = "1.jpg", Price = 1000},
                new Product() { Id = 2, Name ="Samsung S7", ImageUrl = "2.jpg", Price = 2500},
                new Product() { Id = 3, Name ="Samsung S8", ImageUrl = "3.jpg", Price = 3000}
            };

            return products;
        }

        public Product GetOne(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetPopularProducts()
        {
            throw new NotImplementedException();
        }

        public Product GeyById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
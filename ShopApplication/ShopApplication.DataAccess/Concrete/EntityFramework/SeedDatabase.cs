using Microsoft.EntityFrameworkCore;
using ShopApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.DataAccess.Concrete.EntityFramework
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new ShopContext(); // bir context nesnesi ürettik.

            if (context.Database.GetPendingMigrations().Count() == 0) // Eğer bekleyen migration sayısı 0 ise.
            {
                if (context.Categories.Count() == 0)
                {
                    context.Categories.AddRange(Categories);
                }

                if(context.Products.Count() == 0)
                {
                    context.Products.AddRange(Products);
                }

                context.SaveChanges();
            }
        }

        private static Category[] Categories =
        {
            new Category() { Name = "Meyve" },
            new Category() { Name = "Sebze"}
        };

        private static Product[] Products =
        {
            new Product() { Name = "Elma", Price= 5, ImageUrl="1.jpg" },
            new Product() { Name = "Armut", Price= 7, ImageUrl="2.jpg" },
            new Product() { Name = "Muz", Price= 20, ImageUrl="3.jpg" },
            new Product() { Name = "Çilek", Price= 15, ImageUrl="4.jpg" },
        };

    }
}

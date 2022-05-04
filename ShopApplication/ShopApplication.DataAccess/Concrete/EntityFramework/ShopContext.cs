using Microsoft.EntityFrameworkCore;
using ShopApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.DataAccess.Concrete.EntityFramework
{
    public class ShopContext : DbContext // EntityFrameworkCore ile gelen DbContext sınıfı
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // overide ile oluşturduk.
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=DESKTOP-U8RG37D\\SQLSERVER; database=CoreProject; integrated security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductCategory>()
                .HasKey(c => new { c.CategoryId, c.ProductId });
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; } 
    }
}

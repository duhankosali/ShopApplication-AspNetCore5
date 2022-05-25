using ShopApplication.Entities;
using System.Collections.Generic;

namespace ShopApplication.UI.Models
{
    public class ProductModel
    {
        // entities den aldık.
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<Category> SelectedCategories { get; set; }  // Seçilmiş Kategoriler
    }
}

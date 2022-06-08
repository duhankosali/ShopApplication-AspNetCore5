using ShopApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.Business.Abstract
{
    public interface ICartService
    {
        void InitializeCart(string userId); // userId ye göre bir Cart kaydı oluştur.
        Cart GetCartByUserId(string userId);
    }
}

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
    public class CartManager : ICartService
    {
        private ICartDal _cartDal;

        public CartManager(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }

        public Cart GetCartByUserId(string userId)
        {
            //throw new NotImplementedException();

            return _cartDal.GetByUserId(userId);
        }

        public void InitializeCart(string userId)
        {
            //throw new NotImplementedException();

            _cartDal.Create(new Cart()
            {
                UserId = userId,
            });
        }
    }
}

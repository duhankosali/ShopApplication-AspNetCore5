using ShopApplication.DataAccess.Abstract;
using ShopApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.DataAccess.Concrete.EntityFramework
{
    public class EfCoreOrderDal : EfCoreGenericRepository<Order, ShopContext>, IOrderDal
    {
    }
}

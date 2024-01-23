using RestaurantApp.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.DAL
{
    public interface IOrderItemsRepo
    {   
        IEnumerable<OrderItems> GetByOrderId(int orderId);
        int addItems (OrderItems item);
        int deleteItems (OrderItems item);
        int SaveChanges();
    }
}

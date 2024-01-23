using RestaurantApp.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.DAL
{
    public interface IOrdersRepo
    {
        IEnumerable<Order> GetOrders();
        Order? GetOrder(int id);
        IEnumerable<Order>GetOrderByUserId(string userId);
        int AddOrder(Order order);
        int DeleteOrder(Order order);
        int savechanges();
    }
}

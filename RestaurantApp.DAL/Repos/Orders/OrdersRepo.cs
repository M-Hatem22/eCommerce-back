using Microsoft.EntityFrameworkCore.Query;
using RestaurantApp.DAL.Data.Context;
using RestaurantApp.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.DAL
{
    public class OrdersRepo : IOrdersRepo
    {
        private readonly UserContext Context;

        public OrdersRepo(UserContext context)
        {
            Context = context;
        }
        public IEnumerable<Order> GetOrders()
        {
            return Context.Set<Order>();
        }
        public Order? GetOrder(int id)
        {
            return Context.Set<Order>().Find(id);
        }
      
        public int AddOrder(Order order)
        {
            Context.Add(order);
            savechanges();
            return order.Id;
        }

        public int DeleteOrder(Order order)
        {
            Context.Set<Order>().Remove(order);
            savechanges();
            return 1;
        }

        

        public int savechanges()
        {
            return Context.SaveChanges();
        }

        public IEnumerable<Order> GetOrderByUserId(string userId)
        {
            return Context.Set<Order>().Where(O => O.UserId == userId);
        }
    }
}

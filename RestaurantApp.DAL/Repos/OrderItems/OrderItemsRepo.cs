using RestaurantApp.DAL.Data.Context;
using RestaurantApp.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.DAL
{
    public class OrderItemsRepo : IOrderItemsRepo
    {
        private readonly UserContext _context;

        public OrderItemsRepo(UserContext context)
        {
            _context = context;
        }
        public int addItems(OrderItems item)
        {
            _context.Add(item);
            SaveChanges();
            return 1;
        }

        public int deleteItems(OrderItems item)
        {
            _context.Set<OrderItems>().Remove(item);
            return 1;
        }

        public IEnumerable<OrderItems> GetByOrderId(int orderId)
        {
            return _context.Set<OrderItems>().Where(a => a.OrderId == orderId);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}

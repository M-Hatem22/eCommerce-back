using RestaurantApp.BL.DTOs.Orders;
using RestaurantApp.DAL;
using RestaurantApp.DAL.Data.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.BL.Managers.Orders
{
    public class OrdersManager : IOrdersManager
    {
        private readonly IOrdersRepo ordersRepo;

        public OrdersManager(IOrdersRepo ordersRepo)
        {
            this.ordersRepo = ordersRepo;
        }
        public IEnumerable<OrderReadDto> GetOrders()
        {
            var ordersfromDb = ordersRepo.GetOrders();
            return ordersfromDb.Select(o => new OrderReadDto {
                Id=o.Id,
                UserId=o.UserId,
                totalPrice=o.totalPrice
            });
        }
        public OrderReadDto? GetOrder(int id)
        {
            var order = ordersRepo.GetOrder(id);
            if (order == null) return null;
            return new OrderReadDto
            {
                Id = order.Id,
                UserId = order.UserId,
                totalPrice = order.totalPrice
            };
        }

        public IEnumerable<OrderReadDto> GetOrderByUserId(string userId)
        {
            var orders = ordersRepo.GetOrderByUserId(userId);
            
            return orders.Select(o=> new  OrderReadDto
            {
                Id = o.Id,
                UserId = o.UserId,
                totalPrice = o.totalPrice
            });
        }

        
        public int AddOrder(OrderAddDto orderFromRequest, string userId)
        {
            Order order = new Order
            {
                UserId = userId,
                totalPrice = orderFromRequest.totalPrice,
                OrderItems = orderFromRequest.Items.Select(i => new OrderItems
                {
                    ItemId = i.Itemid,
                    Quantity = i.Quantity
                }).ToList()
            };
            ordersRepo.AddOrder(order);
            ordersRepo.savechanges();
            return order.Id;
        }

        

        public int DeleteOrder(int id)
        {
            Order? order = ordersRepo.GetOrder(id);
            if(order ==null) return 0;
            ordersRepo.DeleteOrder(order);
            ordersRepo.savechanges();
            return 1;
        }

       
    }
}

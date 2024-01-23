using RestaurantApp.BL.DTOs.Orders;
using RestaurantApp.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.BL.Managers.Orders
{
    public interface IOrdersManager
    {
        IEnumerable<OrderReadDto> GetOrders();
        OrderReadDto? GetOrder(int id);
        IEnumerable<OrderReadDto> GetOrderByUserId(string userId);
        int AddOrder(OrderAddDto order, string userId);
        int DeleteOrder(int id);
        
    }
}


using RestaurantApp.BL.DTOs.OrderItemsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.BL
{
    public interface IOrderItemsManager
    {
        IEnumerable<OrderItemsReadDto> GetByOrderId(int orderId);
        int addItems(OrderItemsAddDto item);
        
    }
}

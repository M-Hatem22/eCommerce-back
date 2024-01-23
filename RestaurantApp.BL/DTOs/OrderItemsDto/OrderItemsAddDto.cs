using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.BL.DTOs.OrderItemsDto
{
    public class OrderItemsAddDto
    {
        public int OrderId { get; set; }
        public int itemId { get; set; }
        public int quantity { get; set; }
    }
}

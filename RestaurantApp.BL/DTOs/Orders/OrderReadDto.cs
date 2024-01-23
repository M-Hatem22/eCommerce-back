using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.BL.DTOs.Orders
{
    public class OrderReadDto
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public decimal totalPrice { get; set; }
    }
}

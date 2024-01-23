using RestaurantApp.BL.DTOs.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.BL.DTOs.Orders
{
    public class OrderAddDto
    {
        //public int Id { get; set; }
        //public string UserId { get; set; } = string.Empty;
        public decimal totalPrice { get; set; }
        public List<ItemChildDto> Items { get; set; }=new List<ItemChildDto>();
    }
}

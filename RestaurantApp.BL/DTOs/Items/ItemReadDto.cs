using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.BL.DTOs
{
    public class ItemReadDto
    {
        public int Id { get; set; }
        public string name { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public string brandName { get; set; } = string.Empty;
        public string category { get; set; } = string.Empty;
        public decimal price { get; set; } = 0;
        public string image { get; set; } = string.Empty;
    }
}

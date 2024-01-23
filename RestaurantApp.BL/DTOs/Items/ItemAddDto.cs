using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.BL.DTOs.Items
{
    public class ItemAddDto
    {
        public string name {  get; set; }=string.Empty;
        public string Description { get; set; } = string.Empty;
        public int brandId { get; set; } = 0;

        public int QuantityInInventory { get; set; } = 0;
        public decimal price { get; set; } = 0;
        public string image { get; set; } = string.Empty;
    }
}

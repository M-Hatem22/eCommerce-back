using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.DAL.Data.Models
{
    public class Item
    {
        public int Id { get; set; } = 0;
        public int QuantityInInventory { get; set; }= 0;
        public string Name { get; set; } = string.Empty;
        [ForeignKey("brand")]
        public int brandId { get; set; } = 0;
        public brand brand { get; set; } = new();
        public string Description { get; set; } = string.Empty;
        [Column(TypeName = "decimal(10,2)")]
        public decimal price { get; set; } = 0;
        [AllowNull]
        public string? image { get; set; } = string.Empty;
        public List<OrderItems> OrderItems = new();

    }
}

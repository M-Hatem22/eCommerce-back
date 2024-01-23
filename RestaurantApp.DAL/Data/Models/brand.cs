using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.DAL.Data.Models
{
    public class brand
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;

        public string image { get; set; } = string.Empty;
        [ForeignKey("category")]
        public int categoryId { get; set; }= 0;
        public category category { get; set; } = new();
        public List<Item> items { get; set; }= new();
    }
}

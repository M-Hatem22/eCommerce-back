using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.BL.DTOs.Brands;

public class BrandReadDto
{
    public int Id { get; set; } = 0;
    public string name { get; set; } = string.Empty;
    public string image { get; set; } = string.Empty;
    public string category { get; set; } = string.Empty;
}

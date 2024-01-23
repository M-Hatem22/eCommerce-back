using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.BL.DTOs.Brands;

public class BrandAddDto
{
    public string name { get; set; } = string.Empty;
    public string image { get; set; } = string.Empty;

    public int categoryid { get; set; } =0;
}

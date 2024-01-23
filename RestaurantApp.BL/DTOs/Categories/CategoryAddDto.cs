using RestaurantApp.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.BL.DTOs.Categories;

public class CategoryAddDto
{
    public string Name { get; set; } = string.Empty;
    public string image { get; set; } = string.Empty;

}

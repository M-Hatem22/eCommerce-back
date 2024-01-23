using RestaurantApp.BL.DTOs.Items;
using RestaurantApp.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.BL.DTOs.Categories;

namespace RestaurantApp.BL;

public interface ICategoriesManager
{
    IEnumerable<CategoryReadDto> GetCategories();
    CategoryReadDto? GetCategoryById(int id);
    int AddCategory(CategoryAddDto item);
    int deleteCategory(int id);
}

using RestaurantApp.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.DAL.Repos.Categories;

public interface IcategoriesRepo
{
    IEnumerable<category> GetCategories();
    category? GetCategoryById(int id);
    int AddCategory(category category);
    int deleteCategory(category category);
    int saveChanges();
}


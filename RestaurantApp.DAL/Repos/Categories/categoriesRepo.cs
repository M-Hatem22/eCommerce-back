using RestaurantApp.DAL.Data.Context;
using RestaurantApp.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.DAL.Repos.Categories;

public class categoriesRepo : IcategoriesRepo
{
    private readonly UserContext context;

    public categoriesRepo(UserContext context)
    {
        this.context = context;
    }
    public IEnumerable<category> GetCategories()
    {
        return context.Set<category>();
    }
    public category? GetCategoryById(int id)
    {
        return context.Set<category>().Find(id);
    }
    public int AddCategory(category category)
    {
        context.Add(category);
        saveChanges();
        return 1;
    }

    public int deleteCategory(category category)
    {
        context.Set<category>().Remove(category);
        return 1;
    }
    public int saveChanges()
    {
        return context.SaveChanges();
    }
}

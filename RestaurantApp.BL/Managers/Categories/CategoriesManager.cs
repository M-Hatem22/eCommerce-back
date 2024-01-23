using RestaurantApp.BL.DTOs;
using RestaurantApp.BL.DTOs.Categories;
using RestaurantApp.BL.DTOs.Items;
using RestaurantApp.DAL.Data.Models;
using RestaurantApp.DAL.Repos.Categories;
using RestaurantApp.DAL.Repos.Items;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.BL;

public class CategoriesManager : ICategoriesManager
{

    private readonly IcategoriesRepo CatRepo;

    public CategoriesManager(IcategoriesRepo CatRepo) //should use new constructor line instead
    {
        this.CatRepo = CatRepo;
    }
    public IEnumerable<CategoryReadDto> GetCategories()
    {
        var itemsfromdb = CatRepo.GetCategories();
        return itemsfromdb.Select(i => new CategoryReadDto
        {
            Id = i.Id,
            name = i.Name,
            image = i.image
        });
    }
    public CategoryReadDto? GetCategoryById(int id)
    {
        category? itemfromdb = CatRepo.GetCategoryById(id);
        if (itemfromdb == null) return null;
        return new CategoryReadDto
        {
            Id = itemfromdb.Id,
            name = itemfromdb.Name,
            image = itemfromdb.image
        };
    }

    //public IEnumerable<CategoryReadDto>? GetItemByCategory(string category)
    //{
    //    var itemfromdb = itemRepo.GetItemByCategory(category);
    //    if (itemfromdb == null) return null;
    //    return itemfromdb.Select(i => new ItemReadDto
    //    {
    //        Id = i.Id,
    //        name = i.Name,
    //        //category = i.Category,
    //        price = i.price,
    //        description = i.Description,
    //        image = i.image
    //    });
    //}


    public int AddCategory(CategoryAddDto item)
    {
        //should use Automapper instead
        category itemtodb = new category
        {
            Name = item.Name,
            image = item.image
        };
        CatRepo.AddCategory(itemtodb);
        CatRepo.saveChanges();
        return itemtodb.Id;
    }

    public int deleteCategory(int id)
    {
        category? itemtofind = CatRepo.GetCategoryById(id);
        if (itemtofind == null) return 0;
        CatRepo.deleteCategory(itemtofind);
        CatRepo.saveChanges();
        return 1;
    }
}

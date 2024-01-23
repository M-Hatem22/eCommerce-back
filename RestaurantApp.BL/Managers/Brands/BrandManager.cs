using RestaurantApp.BL.DTOs.Items;
using RestaurantApp.BL.DTOs;
using RestaurantApp.DAL.Data.Models;
using RestaurantApp.DAL.Repos.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.DAL.Repos.Brands;
using RestaurantApp.BL.DTOs.Brands;
using RestaurantApp.DAL.Repos.Categories;

namespace RestaurantApp.BL;

public class BrandManager:IBrandManager
{
    private readonly IBrandsRepo BrandRepo;
    private readonly IcategoriesRepo iCatRepo;

    public BrandManager(IBrandsRepo BrandRepo , IcategoriesRepo iCatRepo) //should use new constructor line instead
    {
        this.BrandRepo = BrandRepo;
        this.iCatRepo = iCatRepo;
    }
    public IEnumerable<BrandReadDto> GetBrands()
    {
        var brandFromDb = BrandRepo.GetBrands();
        return brandFromDb.Select(i => new BrandReadDto
        {
            Id = i.Id,
            name = i.Name,
            category = i.category.Name,
            image = i.image
        });
    }
    public BrandReadDto? GetBrandById(int id)
    {
        var itemfromdb = BrandRepo.GetBrandById(id);
        if (itemfromdb == null) return null;
        return new BrandReadDto
        {
            Id = itemfromdb.Id,
            name = itemfromdb.Name,
            category = itemfromdb.category.Name,
            image = itemfromdb.image
        };
    }



    public int AddBrand(BrandAddDto item)
    {
        //should use Automapper instead
        brand itemtodb = new brand
        {
            Name = item.name,
            category= iCatRepo.GetCategoryById(item.categoryid),
            image = item.image
        };
        BrandRepo.AddBrand(itemtodb);
        BrandRepo.saveChanges();
        return itemtodb.Id;
    }

    public int deleteItem(int id)
    {
        brand? itemtofind = BrandRepo.GetBrandById(id);
        if (itemtofind == null) return 0;
        BrandRepo.deleteBrand(itemtofind);
        BrandRepo.saveChanges();
        return 1;
    }
}

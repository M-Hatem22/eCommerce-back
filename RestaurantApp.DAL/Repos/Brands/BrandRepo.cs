using Microsoft.EntityFrameworkCore;
using RestaurantApp.DAL.Data.Context;
using RestaurantApp.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.DAL.Repos.Brands;

public class BrandRepo : IBrandsRepo
{

    private readonly UserContext context;

    public BrandRepo(UserContext context)
    {
        this.context = context;
    }
    public IEnumerable<brand> GetBrands()
    {
        return context.Set<brand>();
    }
    public brand? GetBrandById(int id)
    {
        return context.Set<brand>().Find(id);
    }
    public int AddBrand(brand item)
    {
        context.Add(item);
        saveChanges();
        return 1;
    }

    public int deleteBrand(brand item)
    {
        context.Set<brand>().Remove(item);
        return 1;
    }
    public int saveChanges()
    {
        return context.SaveChanges();
    }
}

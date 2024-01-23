using RestaurantApp.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.DAL.Repos.Brands;

public interface IBrandsRepo
{
    IEnumerable<brand> GetBrands();
    brand? GetBrandById(int id);
    int AddBrand(brand brand);
    int deleteBrand(brand brand);
    int saveChanges();
}

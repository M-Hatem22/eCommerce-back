using RestaurantApp.BL.DTOs.Items;
using RestaurantApp.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.BL.DTOs.Brands;

namespace RestaurantApp.BL;

public interface IBrandManager
{
    IEnumerable<BrandReadDto> GetBrands();
    BrandReadDto? GetBrandById(int id);
    int AddBrand(BrandAddDto item);
    int deleteItem(int id);
}

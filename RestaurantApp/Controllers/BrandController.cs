using Microsoft.AspNetCore.Mvc;
using RestaurantApp.BL;
using RestaurantApp.BL.DTOs.Items;
using RestaurantApp.BL.DTOs;
using RestaurantApp.BL.DTOs.Brands;

namespace RestaurantApp.APIs.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandController : ControllerBase
{
    private readonly IBrandManager brandManager;

    public BrandController(IBrandManager brandManager)
    {
        this.brandManager = brandManager;
    }

    [HttpGet]
    public ActionResult<List<BrandReadDto>> GetAllItems()
    {
        return brandManager.GetBrands().ToList();
    }

    [HttpPost]
    public ActionResult AddItem(BrandAddDto newitem)
    {
        if (newitem == null) { return BadRequest(); }
        var id = brandManager.AddBrand(newitem);
        return Ok();
    }
    [HttpGet]
    [Route("brand/{id}")]
    public ActionResult<BrandReadDto> GetBrandById(int id)
    {
        if (id == 0)
        {
            return NotFound();
        }

        var item = brandManager.GetBrandById(id);
        if (item is null) return BadRequest();
        return item;
    }
}

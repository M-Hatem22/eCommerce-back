using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.BL;
using RestaurantApp.BL.DTOs.Items;
using RestaurantApp.BL.DTOs;
using RestaurantApp.BL.DTOs.Categories;

namespace RestaurantApp.APIs.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoriesManager catManager;

    public CategoriesController(ICategoriesManager CatManager)
    {
        catManager = CatManager;
    }

    [HttpGet]
    public ActionResult<List<CategoryReadDto>> GetAllCategories()
    {
        return catManager.GetCategories().ToList();
    }

    [HttpPost]
    public ActionResult AddCategory(CategoryAddDto newitem)
    {
        if (newitem == null) { return BadRequest(); }
        var id = catManager.AddCategory(newitem);
        return Ok();
    }
    [HttpGet]
    [Route("category/{id}")]
    public ActionResult<CategoryReadDto> GetCategoryById(int id)
    {
        if (id == 0)
        {
            return NotFound();
        }

        var item = catManager.GetCategoryById(id);
        if (item is null) return BadRequest();
        return item;
    }
}

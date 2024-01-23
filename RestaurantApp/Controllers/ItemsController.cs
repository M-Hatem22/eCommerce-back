using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.BL;
using RestaurantApp.BL.DTOs;
using RestaurantApp.BL.DTOs.Items;
using RestaurantApp.DAL.Data.Models;
using System.ComponentModel;

namespace RestaurantApp.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsManager itemsManager;

        public ItemsController(IItemsManager itemsManager)
        {
            this.itemsManager = itemsManager;
        }
        [HttpGet]
        public ActionResult<List<ItemReadDto>> GetAllItems()
        {
            return itemsManager.GetItems().ToList();
        }

        [HttpPost]
        public ActionResult AddItem(ItemAddDto newitem)
        {
            if(newitem == null) { return BadRequest(); }
            var id = itemsManager.AddItem(newitem);
            return Ok();
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<ItemReadDto> GetItemById(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var item= itemsManager.GetItemById(id);
            if (item is null) return BadRequest();
            return item;
        }
        //[HttpGet]
        //[Route("category/{category}")]
        //public ActionResult<List<ItemReadDto>?> GetItemByCategory(string category)
        //{
        //    if (category == null) return NotFound();
        //    var items = itemsManager.GetItemByCategory(category);
        //    if (items is null) return NotFound();
        //    return items.ToList();
        //}
    }
}

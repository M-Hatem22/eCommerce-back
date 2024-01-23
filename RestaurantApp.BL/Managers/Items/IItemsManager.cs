using RestaurantApp.BL.DTOs;
using RestaurantApp.BL.DTOs.Items;
using RestaurantApp.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.BL
{
    public interface IItemsManager
    {
        IEnumerable<ItemReadDto> GetItems();
        ItemReadDto? GetItemById(int id);
        IEnumerable<ItemReadDto>? GetItemByCategory(string category);
        int AddItem(ItemAddDto item);
        void AddItemByList(IEnumerable<ItemAddDto> items);
        void updateInventoryByList(IEnumerable<ItemAddDto> items);
        int deleteItem(int id);
        
    }
}

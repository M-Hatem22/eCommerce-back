using RestaurantApp.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.DAL.Repos.Items
{
    public interface IItemtsReop
    {
        IEnumerable<Item> GetItems();
        Item? GetItemById(int id);
        IEnumerable<Item>? GetItemByCategory(string category);
        int AddItem(Item item);
        int deleteItem(Item item);
        void deleteAllItems();

        int saveChanges();
    }
}

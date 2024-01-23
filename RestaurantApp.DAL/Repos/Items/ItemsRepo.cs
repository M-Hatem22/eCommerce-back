using RestaurantApp.DAL.Data.Context;
using RestaurantApp.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.DAL.Repos.Items
{
    public class ItemsRepo : IItemtsReop
    {
        private readonly UserContext context;

        public ItemsRepo(UserContext context)
        {
            this.context = context;
        }
        public IEnumerable<Item> GetItems()
        {
            return context.Set<Item>();
        }
        public Item? GetItemById(int id)
        {
            return context.Set<Item>().Find(id);
        }
        public IEnumerable<Item>? GetItemByCategory(string category)
        {
            return context.Set<Item>();
                //.Where(a=>a.Category==category);
        }
        public int AddItem(Item item)
        {
            context.Add(item);
            saveChanges();
            return 1;
        }

        public int deleteItem(Item item)
        {
            context.Set<Item>().Remove(item);
            return 1;
        }
        public void deleteAllItems()
        {
            context.RemoveRange(context.Set<Item>().ToList());
        }
        public int saveChanges()
        {
            return context.SaveChanges();
        }
    }
}

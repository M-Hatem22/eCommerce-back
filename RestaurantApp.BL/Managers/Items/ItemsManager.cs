using RestaurantApp.BL.DTOs;
using RestaurantApp.BL.DTOs.Items;
using RestaurantApp.DAL.Data.Models;
using RestaurantApp.DAL.Repos.Brands;
using RestaurantApp.DAL.Repos.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.BL
{
    public class ItemsManager : IItemsManager
    {
        private readonly IItemtsReop itemRepo;
        private readonly IBrandsRepo iBrandRepo;

        public ItemsManager(IItemtsReop itemRepo , IBrandsRepo iBrandRepo) //should use new constructor line instead
        {
            this.itemRepo = itemRepo;
            this.iBrandRepo = iBrandRepo;
        }
        public IEnumerable<ItemReadDto> GetItems()
        {
            var itemsfromdb = itemRepo.GetItems();
            return itemsfromdb.Select(i => new ItemReadDto
            {
                Id = i.Id,
                name = i.Name,
                brandName=i.brand.Name,
                category=i.brand.category.Name,
                price = i.price,
                description = i.Description,
                image = i.image
            }) ;
        }
        public ItemReadDto? GetItemById(int id)
        {
            Item? itemfromdb = itemRepo.GetItemById(id);
            if (itemfromdb == null) return null;
            return new ItemReadDto
            {
                Id = itemfromdb.Id,
                name = itemfromdb.Name,
                category = itemfromdb.brand.category.Name,
                brandName = itemfromdb.brand.Name,
                price = itemfromdb.price,
                description = itemfromdb.Description,
                image = itemfromdb.image
            };
        }

        public IEnumerable<ItemReadDto>? GetItemByCategory(string category)
        {
            var itemfromdb = itemRepo.GetItemByCategory(category);
            if (itemfromdb == null) return null;
            return itemfromdb.Select(i => new ItemReadDto
            {
                Id = i.Id,
                name = i.Name,
                //category = i.Category,
                price = i.price,
                description = i.Description,
                image = i.image
            });
        }


        public int AddItem(ItemAddDto item)
        {
            //should use Automapper instead
            Item itemtodb = new Item
            {
                Name = item.name,
                brand = iBrandRepo.GetBrandById(item.brandId),
                price = item.price,
                QuantityInInventory = item.QuantityInInventory,
                Description = item.Description,
                image = item.image
            };
            itemRepo.AddItem(itemtodb);
            itemRepo.saveChanges();
            return itemtodb.Id;
        }
        public void AddItemByList(IEnumerable<ItemAddDto> items)
        {
            foreach (var item in items)
            {
                //this variable should be in program.cs
                var noImage = "https://localhost:7129/Images/e953b851-d70b-49c1-8534-7e996699cecd.png";
                item.image = item.image == string.Empty ? noImage : item.image;
                _ = AddItem(item);
            }
        }

        public void updateInventoryByList(IEnumerable<ItemAddDto> items)
        {
            itemRepo.deleteAllItems();
            AddItemByList(items);
        }

        public int deleteItem(int id)
        {
            Item? itemtofind = itemRepo.GetItemById(id);
            if (itemtofind == null) return 0;
            itemRepo.deleteItem(itemtofind);
            itemRepo.saveChanges();
            return 1;
        }

      
    }
}

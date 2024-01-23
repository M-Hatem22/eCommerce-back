

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantApp.DAL.Data.Models;

namespace RestaurantApp.DAL.Data.Context
{
    public class UserContext : IdentityDbContext<User>
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<category> categories { get; set; }
        
        public DbSet<brand> brands { get; set; }
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>().HasMany(o => o.OrderItems).WithOne(o => o.Order).HasForeignKey(o=>o.OrderId);

            modelBuilder.Entity<Item>().
                HasMany(o => o.OrderItems).
                WithOne(o => o.Item).
                HasForeignKey(o => o.ItemId);
            modelBuilder.Entity<brand>().HasOne(o => o.category);

            
            modelBuilder.Entity<Item>().HasOne(o => o.brand);

            modelBuilder.Entity<Item>().Navigation(e => e.brand).AutoInclude();
            
            modelBuilder.Entity<brand>().Navigation(e => e.category).AutoInclude();




        }


    }
    }


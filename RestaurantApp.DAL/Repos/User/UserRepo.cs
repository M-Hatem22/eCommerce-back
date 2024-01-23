using Microsoft.EntityFrameworkCore;
using RestaurantApp.DAL.Data.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.DAL
{
    public class UserRepo : IUserRepo
    {
        private readonly UserContext context;

        public UserRepo(UserContext context)
        {
            this.context = context;
        }
        public IEnumerable<DAL.User> GetAllUsers()
        {
            return context.Set<User>().AsNoTracking();
        }

        public DAL.User? GetUserById(string id)
        {
            return context.Set<User>().Find(id);
        }

        public IEnumerable<DAL.User> GetUsersByType(string type)
        {
            return context.Set<User>().Where(a => a.Type == type).ToList();
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }
    }
}

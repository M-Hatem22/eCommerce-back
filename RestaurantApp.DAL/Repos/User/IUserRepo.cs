using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.DAL
{
    public interface IUserRepo
    {
        public User? GetUserById(string id);
        public IEnumerable<User> GetAllUsers();
        public IEnumerable<User> GetUsersByType(string type);
        public int SaveChanges();
    }
}

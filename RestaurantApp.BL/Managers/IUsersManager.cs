using RestaurantApp.BL.DTOs.Login_and_Register;
using RestaurantApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.BL.Managers
{
    public interface IUsersManager
    {
        Task<TokenDto> Login(LoginDto login);
        Task<RegisterResult> Register(RegisterDto registerDto);
        public UserReadDto? GetUserById(string id);
        public IEnumerable<UserReadDto> GetAllUsers();
        public IEnumerable<UserReadDto> GetUsersByType(string type);
    }
}

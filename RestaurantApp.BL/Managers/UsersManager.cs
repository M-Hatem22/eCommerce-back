using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RestaurantApp.BL.DTOs.Login_and_Register;
using RestaurantApp.DAL;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.BL.Managers
{
    public class UsersManager : IUsersManager
    {
        
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly IUserRepo userRepo;

        public UsersManager( IConfiguration configuration, UserManager<User> userManager , IUserRepo userRepo)
        {
          
            _configuration = configuration;
            _userManager = userManager;
            this.userRepo = userRepo;
        }

        private TokenDto GenerateToken(IList<Claim> claimsList)
        {
            string keyString = _configuration.GetValue<string>("SecretKey")?? string.Empty;
            var keyInBytes = Encoding.ASCII.GetBytes(keyString);
            var key = new SymmetricSecurityKey(keyInBytes);

            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var expiry = DateTime.Now.AddMinutes(15);

            var jwt = new JwtSecurityToken(
                expires: expiry,
                claims: claimsList,
                signingCredentials: signingCredentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(jwt);

            return new TokenDto(TokenResult.Success, tokenString, expiry);
        }
        public async Task<TokenDto> Login(LoginDto login)
        {
            User? user = await _userManager.FindByNameAsync(login.UserName);
            if (user == null)
            {
                return new TokenDto(TokenResult.Failure);
            }

            bool isPasswordCorrect = await _userManager.CheckPasswordAsync(user, login.Password);
            if (!isPasswordCorrect)
            {
                return new TokenDto(TokenResult.UserpasswordError);
            }

            var claimList = await _userManager.GetClaimsAsync(user);
            var token = GenerateToken(claimList);
            token.Role = user.Type;
            return token;
        }

        public async Task<RegisterResult> Register(RegisterDto registerDto)
        {
            var newUser = new User
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                Type = "user"
            };

            var creationResult = await _userManager.CreateAsync(newUser, registerDto.Password);
            if (!creationResult.Succeeded)
            {
                return new RegisterResult(false, creationResult.Errors);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, newUser.Id),
                new Claim(ClaimTypes.Role, newUser.Type)
            };

            await _userManager.AddClaimsAsync(newUser, claims);

            return new RegisterResult(true);
        }

        
        

        UserReadDto? IUsersManager.GetUserById(string id)
        {
            User? userfromDb = userRepo.GetUserById(id);
            if (userfromDb is null) return null;
            return new UserReadDto
            {
                UserId = userfromDb.Id,
                UserEmail = userfromDb.Email,
                Type = userfromDb.Type,
                UserName = userfromDb.UserName
            };
        }

        IEnumerable<UserReadDto> IUsersManager.GetAllUsers()
        {
            var users = userRepo.GetAllUsers();
            return users.Select(r => new UserReadDto
            {
                UserId = r.Id,
                UserEmail = r.Email,
                UserName = r.UserName,
                Type = r.Type
            });
        }

        IEnumerable<UserReadDto> IUsersManager.GetUsersByType(string type)
        {
            var users = userRepo.GetUsersByType(type);
            return users.Select(r => new UserReadDto
            {
                UserId = r.Id,
                UserEmail = r.Email,
                UserName = r.UserName,
                Type = r.Type
            });
        }
    }
 }


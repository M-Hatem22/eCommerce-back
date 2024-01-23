using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.BL.DTOs.Login_and_Register
{
    public enum TokenResult
    {
        Success = 0,
        UserNameError = 1,
        UserpasswordError = 2,
        Failure = 3,
    }
    public class TokenDto
    {
        public TokenDto(TokenResult result, string token = "", DateTime expire = default, string role = "")
        {
            Result = result;
            Token = token;
            Expiry = expire;
            Role = role;
        }


        public TokenResult Result { get; set; }
        public string Token { get; set; } = string.Empty;
        [Column(TypeName = "date")]
        public DateTime Expiry { get; set; }
        public string Role { get; set; } = string.Empty;
    }
}

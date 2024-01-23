using Microsoft.AspNetCore.Identity;

namespace RestaurantApp.DAL;

public class User :IdentityUser
{
    public string Type { get; set; } = string.Empty;
}

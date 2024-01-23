using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using RestaurantApp.APIs.Hubs;
using RestaurantApp.BL;
using RestaurantApp.BL.Managers;
using RestaurantApp.BL.Managers.Orders;
using RestaurantApp.DAL;
using RestaurantApp.DAL.Data.Context;
using RestaurantApp.DAL.Repos.Brands;
using RestaurantApp.DAL.Repos.Categories;
using RestaurantApp.DAL.Repos.Items;
using System.Text;

namespace RestaurantApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

          
            //-------------------

            builder.Services.AddDbContext<UserContext>(options =>
                 options.UseSqlServer(builder.Configuration.GetConnectionString("Restaurant_DB")));

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.AllowAnyOrigin()
                                      .AllowAnyHeader()
                                      .AllowAnyMethod()
                                      .AllowCredentials()
                                      .WithOrigins("http://localhost:4200");
                                  });
            });
            //----------------------

            builder.Services.AddScoped<IUsersManager, UsersManager>();
            builder.Services.AddScoped<IUserRepo, UserRepo>();

            builder.Services.AddScoped<IItemtsReop, ItemsRepo>();
            builder.Services.AddScoped<IItemsManager, ItemsManager>();

            builder.Services.AddScoped<IOrderItemsManager, OrderItemsManager>();
            builder.Services.AddScoped<IOrderItemsRepo, OrderItemsRepo>();

            builder.Services.AddScoped<IOrdersRepo, OrdersRepo>();
            builder.Services.AddScoped<IOrdersManager, OrdersManager>();

            builder.Services.AddScoped<IBrandsRepo, BrandRepo>();
            builder.Services.AddScoped<IBrandManager, BrandManager>();

            builder.Services.AddScoped<IcategoriesRepo, categoriesRepo>();
            builder.Services.AddScoped<ICategoriesManager, CategoriesManager>();
            //--------------------

            builder.Services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireDigit = false;

                options.User.RequireUniqueEmail = true;

                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
            })
                 .AddEntityFrameworkStores<UserContext>();
            ///--------------------------
            ///


            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = "default";
                option.DefaultChallengeScheme = "default";

            }).AddJwtBearer("default", option =>
            {
                string keyString = builder.Configuration.GetValue<string>("SecretKey") ?? string.Empty;
                var keyInBytes = Encoding.ASCII.GetBytes(keyString);
                var key = new SymmetricSecurityKey(keyInBytes);

                option.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = key,
                    ValidateIssuer = false,
                    ValidateAudience = false,

                };

            });

            builder.Services.AddSignalR();

            //builder.Services.AddIdentity<IdentityUser, IdentityRole>()
            //.AddEntityFrameworkStores<UserContext>()
            //.AddDefaultTokenProviders();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(MyAllowSpecificOrigins);

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();
            var staticFilesPath = Path.Combine(Environment.CurrentDirectory, "Images");
            app.UseStaticFiles(new StaticFileOptions
            {
                //FileProvider=new PhysicalFileProvider("D:\\iti\\ArabComputers\\Back\\RestaurantApp\\RestaurantApp\\Images\\")
                FileProvider = new PhysicalFileProvider(staticFilesPath),
                RequestPath = "/Images"
            });
            
            app.MapControllers();
            app.MapHub<userHub>("/hubs");
            app.Run();
        }
    }
}
using InventoryManagementSystem.BLL.AutoMapper;
using InventoryManagementSystem.BLL.Manager;
using InventoryManagementSystem.BLL.Manager.UserManager;
using InventoryManagementSystem.BLL.Manager.ShoppingCartManager;
using InventoryManagementSystem.BLL.Manager.PaymentManager;
using InventoryManagementSystem.BLL.Manager.CategoryManager;
using InventoryManagementSystem.BLL.Manager.PurchaseManager;
using InventoryManagementSystem.BLL.Manager.OrderManager;
using InventoryManagementSystem.BLL.Manager.OrderProductManager;
using InventoryManagementSystem.BLL.Manager.CompanyManager;
using InventoryManagementSystem.BLL.Manager.ProductVariantManager;
using InventoryManagementSystem.BLL.Manager.CartProductManager;
using InventoryManagementSystem.BLL.Manager.AccountManager;
using InventoryManagementSystem.DAL.Data.Models;
using InventoryManagementSystem.DAL.Reposatiries; 
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using InventoryManagementSystem.DAL.Data.DbHelper;
using InventoryManagementSystem.DAL.Reposatiries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace InventoryManagementSystem.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Add AutoMapper
            builder.Services.AddAutoMapper(config => config.AddProfile(new MappingProfile()));

            // Add Repositories and Managers
            RegisterServices(builder.Services);

            // Configure Identity
            builder.Services.AddIdentity<User, IdentityRole<int>>()
                .AddEntityFrameworkStores<InventoryManagementSystemContext>()
                .AddDefaultTokenProviders();

            // Configure the DbContext
            builder.Services.AddDbContext<InventoryManagementSystemContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Configure session timeout
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(30);
                options.Cookie.HttpOnly = true;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // Show detailed errors in development
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts(); // Use HSTS in production
            }
            //builder.Services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //     {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,
            //    };
            //});


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Enable session management
            app.UseSession();

            app.UseAuthentication(); // Enable authentication
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }


        private static void RegisterServices(IServiceCollection services)
        {
            // Register repositories and managers
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<IProductManager, ProductManager>();

            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IUserRepo, UserRepo>();

            services.AddScoped<IShoppingCartManger, ShoppingCartManager>();
            services.AddScoped<IShoppingCartRepo, ShoppingCartRepo>();

            services.AddScoped<IPaymentManager, PaymentManager>();
            services.AddScoped<IPaymentRepo, PaymentRepo>();

            services.AddScoped<ICategoryManager, CategoryManager>();
            services.AddScoped<ICategoryRepo, CategoryRepo>();

            services.AddScoped<IPurchaseManager, PurchaseManager>();
            services.AddScoped<IPurchaseRepo, PurchaseRepo>();

            services.AddScoped<IOrderManager, OrderManager>();
            services.AddScoped<IOrderRepo, OrderRepo>();

            services.AddScoped<IOrderProductManager, OrderProductManager>();
            services.AddScoped<IOrderProductRepo, OrderProductRepo>();

            services.AddScoped<ICompanyManager, CompanyManager>();
            services.AddScoped<ICompanyRepo, CompanyRepo>();

            services.AddScoped<IProductVariantManager, ProductVariantManager>();
            services.AddScoped<IProductVariantRepo, ProductVariantRepo>();

            services.AddScoped<ICartProductManager, CartProductManager>();
            services.AddScoped<ICartProductRepo, CartProductRepo>();

            services.AddScoped<IAccountManager, AccountManager>();
            services.AddScoped<IAccountManager, AccountManager>();
            services.AddScoped<IAccountManager, AccountManager>();
        }
    }
}

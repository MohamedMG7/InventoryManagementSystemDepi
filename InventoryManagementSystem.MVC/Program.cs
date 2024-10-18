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
            builder.Services.AddAutoMapper(map => map.AddProfile(new MappingProfile()));

            // Add Repositories and Managers
            builder.Services.AddScoped<IProductRepo, ProductRepo>();
            builder.Services.AddScoped<IProductManager, ProductManager>();

            builder.Services.AddScoped<IUserManager, UserManager>();
            builder.Services.AddScoped<IUserRepo, UserRepo>();

            builder.Services.AddScoped<IShoppingCartManger, ShoppingCartManager>();
            builder.Services.AddScoped<IShoppingCartRepo, ShoppingCartRepo>();

            builder.Services.AddScoped<IPaymentManager, PaymentManager>();
            builder.Services.AddScoped<IPaymentRepo, PaymentRepo>();

            builder.Services.AddScoped<ICategoryManager, CategoryManager>();
            builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();

            builder.Services.AddScoped<IPurchaseManager, PurchaseManager>();
            builder.Services.AddScoped<IPurchaseRepo, PurchaseRepo>();

            builder.Services.AddScoped<IOrderManager, OrderManager>();
            builder.Services.AddScoped<IOrderRepo, OrderRepo>();

            builder.Services.AddScoped<IOrderProductManager, OrderProductManager>();
            builder.Services.AddScoped<IOrderProductRepo, OrderProductRepo>();

            builder.Services.AddScoped<ICompanyManager, CompanyManager>();
            builder.Services.AddScoped<ICompanyRepo, CompanyRepo>();

            builder.Services.AddScoped<IProductVariantManager, ProductVariantManager>();
            builder.Services.AddScoped<IProductVariantRepo, ProductVariantRepo>();

            builder.Services.AddScoped<ICartProductManager, CartProductManager>();
            builder.Services.AddScoped<ICartProductRepo, CartProductRepo>();

            builder.Services.AddScoped<IAccountManager, AccountManager>();

            // Configure Identity
            builder.Services.AddIdentity<User, IdentityRole<int>>()
                .AddEntityFrameworkStores<InventoryManagementSystemContext>()
                .AddDefaultTokenProviders();

            // Configure the DbContext
            builder.Services.AddDbContext<InventoryManagementSystemContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); // Enable authentication
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

using InventoryManagementSystem.DAL.Data.DbHelper;
using InventoryManagementSystem.DAL.Reposatiries;
using Microsoft.EntityFrameworkCore;
using InventoryManagementSystem.BLL.AutoMapper;
using InventoryManagementSystem.BLL.Manager;
using InventoryManagementSystem.BLL.Manager.UserManager;
using InventoryManagementSystem.BLL.Manager.ShoppingCartManager;
using InventoryManagementSystem.BLL.Manager.PaymentManager;
using InventoryManagementSystem.BLL.Manager.CategoryManager;
using InventoryManagementSystem.BLL.Manager.PurchaseManager;
using InventoryManagementSystem.BLL.Manager.OrderManager;
using InventoryManagementSystem.DAL.Data.Models;
using InventoryManagementSystem.BLL.Manager.OrderProductManager;
using InventoryManagementSystem.BLL.Manager.CompanyManager;
using InventoryManagementSystem.BLL.Manager.ProductVariantManager;
using InventoryManagementSystem.BLL.Manager.CartProductManager;
using InventoryManagementSystem.BLL.Manager.AccountManager;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace InventoryManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add AutoMapper service
            builder.Services.AddAutoMapper(map => map.AddProfile(new MappingProfile()));

            // Scoped Services
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

            // Identity Services
            builder.Services.AddIdentity<User, IdentityRole<int>>()
                .AddEntityFrameworkStores<InventoryManagementSystemContext>()
                .AddDefaultTokenProviders();

            // DbContext
            builder.Services.AddDbContext<InventoryManagementSystemContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add Session services
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Add session middleware
            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}

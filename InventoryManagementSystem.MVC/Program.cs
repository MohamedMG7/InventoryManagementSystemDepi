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
            builder.Services.AddAutoMapper(config => config.AddProfile(new MappingProfile()));

            // Register repositories and managers
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
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Adjusted session timeout to 30 minutes
                options.Cookie.HttpOnly = true; // Ensure the session cookie is HTTP-only
            });

            // Configure Cookie-based authentication
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login"; // Redirect to login if not authenticated
                options.AccessDeniedPath = "/Account/AccessDenied"; // Redirect to access denied page if unauthorized
                options.ExpireTimeSpan = TimeSpan.FromDays(7); // Cookie expires after 7 days
                options.SlidingExpiration = true; // Extend cookie expiration on activity
                options.Cookie.HttpOnly = true; // Ensure cookie cannot be accessed by JavaScript
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Enable authentication and authorization
            app.UseAuthentication(); // Use Cookie-based authentication
            app.UseAuthorization();  // Ensure user has required access rights

            // Enable session management
            app.UseSession();

            // Map default routes for controllers
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }

        // Register services: repositories and managers
        private static void RegisterServices(IServiceCollection services)
        {
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
        }
    }
}

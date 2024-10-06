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
using InventoryManagementSystem.DAL.Data.Models;
namespace InventoryManagementSystem
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(map => map.AddProfile(new MappingProfile()));
			builder.Services.AddScoped<IProductRepo, ProductRepo>();
			builder.Services.AddScoped<IProductManager, ProductManager>();
            //builder.Services.AddScoped<IProductManager, ProductAutoMapperManager>();
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

			builder.Services.AddDbContext<InventoryManagementSystemContext>(options => 
			options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}

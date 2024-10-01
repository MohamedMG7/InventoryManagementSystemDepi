using InventoryManagementSystem.DAL.Data.DbHelper;
using InventoryManagementSystem.DAL.Reposatiries;
using Microsoft.EntityFrameworkCore;
using InventoryManagementSystem.BLL.AutoMapper;
using InventoryManagementSystem.BLL.Manager;
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
			builder.Services.AddScoped<IProductManager, ProductAutoMapperManager>();

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

using InventoryManagementSystem.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.DAL.Data.DbHelper
{
	public class InventoryManagementSystemContext : DbContext
	{
        public InventoryManagementSystemContext(DbContextOptions<InventoryManagementSystemContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<CartProduct>()
				.HasKey(sc => new { sc.ShoppingCartId, sc.ProductId });

			modelBuilder.Entity<OrderProduct>()
				.HasKey(sc => new { sc.OrderId, sc.ProductId });
		}

		public DbSet<Product> Products { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Category> Category { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<ShoppingCart> ShoppingCarts { get; set; }
		public DbSet<Company> Company { get; set; }
		public DbSet<Payment> Payments { get; set; }
		public DbSet<CartProduct> cartProducts { get; set; }
		public DbSet<OrderProduct> orderProducts { get; set; }


	}
}

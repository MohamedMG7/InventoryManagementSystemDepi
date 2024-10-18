using InventoryManagementSystem.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace InventoryManagementSystem.DAL.Data.DbHelper
{
	public class InventoryManagementSystemContext : IdentityDbContext<User, IdentityRole<int>, int>
	{
        public InventoryManagementSystemContext(DbContextOptions<InventoryManagementSystemContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<CartProduct>()
				.HasKey(sc => new { sc.ShoppingCartId, sc.ProductId });

			modelBuilder.Entity<OrderProduct>()
				.HasKey(sc => new { sc.OrderId, sc.ProductVariantId});

			modelBuilder.Entity<PurchaseProduct>()
			   .HasKey(pp => new { pp.PurchaseId, pp.ProductVariantId });

			modelBuilder.Entity<PurchaseProduct>()
		   .HasOne(pp => pp.ProductVariant)      // Specify the relationship to ProductVariant
		   .WithMany(pv => pv.purchaseProducts)  // Assuming ProductVariant has a navigation property to PurchaseProduct
		   .HasForeignKey(pp => pp.ProductVariantId) // Specify the foreign key
		   .OnDelete(DeleteBehavior.Restrict);

			//seeding roles 
			modelBuilder.Entity<IdentityRole<int>>().HasData(
			new IdentityRole<int> { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
			new IdentityRole<int> { Id = 2, Name = "User", NormalizedName = "USER" }
			);
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
        public DbSet<ProductVariant> productVariants { get; set; }
		public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseProduct> PurchaseProducts { get; set; }
    }
}

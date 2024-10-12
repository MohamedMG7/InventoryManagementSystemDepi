
namespace InventoryManagementSystem.DAL.Data.Models
{
	public class Product
	{
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public bool isDeleted { get; set; }


        public int CompanyId { get; set; }
        public Company company { get; set; }

        public int CategoryId { get; set; }
        public Category category { get; set; }

        public int? MinimumStockToRequest { get; set; }
        public int? DiscountPrecentage { get; set; }

        public ICollection<CartProduct> CartProducts { get; set; } = new HashSet<CartProduct>();
        public ICollection<OrderProduct> OrderProducts { get; set; } = new HashSet<OrderProduct>();
        public ICollection<ProductVariant> productVariants { get; set; } = new HashSet<ProductVariant>();
    }
}

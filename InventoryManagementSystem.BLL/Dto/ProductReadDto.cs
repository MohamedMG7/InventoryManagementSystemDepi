using InventoryManagementSystem.DAL.Data.Models;

namespace InventoryManagementSystem.BLL.Dto
{
	public class ProductReadDto
	{
		
		public int ProductId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public double Price { get; set; }
		public string ImageUrl { get; set; }

		public string CompanyName { get; set; }
		public string CategoryName { get; set; }

		public int? MinimumStockToRequest { get; set; }
		public int? DiscountPrecentage { get; set; }

		// List of product variants
		public ICollection<ProductVariantReadDto> ProductVariants { get; set; }
	}
}

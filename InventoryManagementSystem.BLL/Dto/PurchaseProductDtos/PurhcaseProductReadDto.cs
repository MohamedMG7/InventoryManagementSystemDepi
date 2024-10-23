
namespace InventoryManagementSystem.BLL.Dto.PurchaseProductDtos
{
	public class PurhcaseProductReadDto
	{
		public int PurchaseId { get; set; } // Foreign key referencing Purchase
		public int ProductVariantId { get; set; } // Foreign key referencing ProductVariant

		public string ProductName { get; set; }
		public string ProductProviderName { get; set; }

		public int QuantityPurchased { get; set; }
		public double UnitCost { get; set; }
		public double TotalCost { get; set; }
	}
}

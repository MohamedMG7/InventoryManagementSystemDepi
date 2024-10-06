
namespace InventoryManagementSystem.BLL.Dto.PurchaseProductDtos
{
	public class PurchaseProductAddDto
	{
		public int PurchaseId { get; set; }  
		public int ProductVariantId { get; set; }  
		public int QuantityPurchased { get; set; } 
		public double UnitCost { get; set; }  
		public double TotalCost { get; set; }
		// total cost should get calculated automatically
	}
}

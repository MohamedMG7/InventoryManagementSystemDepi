
namespace InventoryManagementSystem.BLL.Dto.PurchaseProductDtos
{
	public class PurchaseProductReadDto
	{
		public int PurchaseProductId { get; set; } 
		public int PurchaseId { get; set; }  
		public int ProductVariantId { get; set; }  
		public string ProductVariantName { get; set; }  
		public int QuantityPurchased { get; set; }  
		public double UnitCost { get; set; }  
		public double TotalCost { get; set; }
	}
}

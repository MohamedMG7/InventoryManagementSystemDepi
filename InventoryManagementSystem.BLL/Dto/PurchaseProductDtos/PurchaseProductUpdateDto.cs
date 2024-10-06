
namespace InventoryManagementSystem.BLL.Dto.PurchaseProductDtos
{
	public class PurchaseProductUpdateDto
	{
		public int PurchaseProductId { get; set; }  
		public int QuantityPurchased { get; set; }  
		public double UnitCost { get; set; }  
		public double TotalCost { get; set; }
	}
}

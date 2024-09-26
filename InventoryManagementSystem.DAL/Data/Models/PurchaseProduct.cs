
namespace InventoryManagementSystem.DAL.Data.Models
{
	public class PurchaseProduct
	{
        public int PurchaseProductId { get; set; }
        public int PurchaseId { get; set; }
        public Purchase purchase { get; set; }
        public int ProductVariantId { get; set; }
        public ProductVariant ProductVariant { get; set; }
        public int QuantityPurchased { get; set; }
        public double UnitCost { get; set; }
        public double TotalCost { get; set; }
    }
}


namespace InventoryManagementSystem.DAL.Data.Models
{
	public class PurchaseProduct
	{
        //public int PurchaseProductId { get; set; } this should be deleted and the pk for this table should be a composite pk 
        public int PurchaseId { get; set; }
        public Purchase purchase { get; set; }
        public int ProductVariantId { get; set; }
        public ProductVariant ProductVariant { get; set; }
        public int QuantityPurchased { get; set; }
        public double UnitCost { get; set; }
        public double TotalCost { get; set; }
        public bool isDeleted { get; set; }
    }
}

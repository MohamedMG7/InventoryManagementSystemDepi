
namespace InventoryManagementSystem.DAL.Data.Models
{
	public class OrderProduct
	{
        public int OrderId { get; set; }
        public Order order { get; set; }

        public int ProductVariantId { get; set; } 
		public ProductVariant ProductVariant { get; set; } 


		public int Quantity { get; set; }
        public double PriceAtPurchase { get; set; }
		public bool isDeleted { get; set; }

	}
}

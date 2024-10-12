
namespace InventoryManagementSystem.DAL.Data.Models
{
	public class OrderProduct
	{
        public int OrderId { get; set; }
        public Order order { get; set; }

        public int ProductId { get; set; }
        public Product product { get; set; }

        
        public int Quantity { get; set; }
        public double PriceAtPurchase { get; set; }
		public bool isDeleted { get; set; }

	}
}

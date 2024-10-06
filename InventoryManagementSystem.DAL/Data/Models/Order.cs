
namespace InventoryManagementSystem.DAL.Data.Models
{
	public class Order
	{
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public string TrackingNumber { get; set; }
        
        public ICollection<Payment> Payments { get; set; }
        public int UserId { get; set; }
        public User user { get; set; }
		public ICollection<OrderProduct> OrderProducts { get; set; }

        public Order() {
            Date = DateTime.Now;
        }

	}
}

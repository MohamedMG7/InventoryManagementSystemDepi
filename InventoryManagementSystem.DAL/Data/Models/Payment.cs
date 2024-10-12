
namespace InventoryManagementSystem.DAL.Data.Models
{
	public class Payment
	{
        public int PaymentId { get; set; }
        public string PaymentType { get; set; }
        public string PaymentStatus { get; set; }
        public TimeOnly PaymentTime { get; set; }
        public bool isDeleted { get; set; }
        public int OrderId { get; set; }
        public Order order { get; set; }

        public Payment()
        {
            PaymentTime = TimeOnly.FromDateTime(DateTime.Now); // Automatically set the current time
        }
    }
}

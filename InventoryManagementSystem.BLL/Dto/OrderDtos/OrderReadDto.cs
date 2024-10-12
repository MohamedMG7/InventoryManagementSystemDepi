
namespace InventoryManagementSystem.BLL.Dto.OrderDtos
{
	public class OrderReadDto
	{
		public int OrderId { get; set; }
		public DateTime Date { get; set; }
		public string TrackingNumber { get; set; }
		public int UserId { get; set; }

	}
}


namespace InventoryManagementSystem.BLL.Dto.OrderDtos
{
	public class ReadOrderWithProductsDto
	{
		public int OrderId { get; set; }
		public DateTime Date { get; set; }
		public string TrackingNumber { get; set; }
		//public ICollection<OrderProductDto> OrderProducts { get; set; }
	}
}

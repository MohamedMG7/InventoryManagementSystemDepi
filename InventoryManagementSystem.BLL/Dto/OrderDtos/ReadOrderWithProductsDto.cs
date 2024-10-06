using InventoryManagementSystem.BLL.Dto.OrderProductDtos;
namespace InventoryManagementSystem.BLL.Dto.OrderDtos
{
	public class ReadOrderWithProductsDto
	{
		public int OrderId { get; set; }
		public DateTime Date { get; set; }
		public string TrackingNumber { get; set; }
		public ICollection<OrderProductReadDto> OrderProducts { get; set; }
	}
}

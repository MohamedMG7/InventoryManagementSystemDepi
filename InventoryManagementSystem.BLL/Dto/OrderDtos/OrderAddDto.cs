using InventoryManagementSystem.DAL.Data.Models;

namespace InventoryManagementSystem.BLL.Dto.OrderDtos
{
	public class OrderAddDto
	{
		public string TrackingNumber { get; set; }
		public int UserId { get; set; }
	}
}

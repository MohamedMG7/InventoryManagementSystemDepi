using InventoryManagementSystem.BLL.Dto.OrderProductDtos;
using InventoryManagementSystem.DAL.Data.Models;

namespace InventoryManagementSystem.BLL.Dto.OrderDtos
{
	public class OrderAddDto
	{
		public string TrackingNumber { get; set; }
		public int UserId { get; set; }
        public ICollection<OrderProductAddDto> Products { get; set; }

		// New properties for payment details
		public string PaymentType { get; set; }
		public string PaymentStatus { get; set; }
	}
}

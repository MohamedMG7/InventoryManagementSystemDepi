

namespace InventoryManagementSystem.BLL.Dto.ShoppingCartDto
{
	public class AdminShoppingCartReadDto
	{
		public int CartId { get; set; }
		public int UserId { get; set; }
		public double TotalPrice { get; set; }
		public bool isDeleted { get; set; }
	}
}

namespace InventoryManagementSystem.BLL.Dto.CartProductDtos
{
	public class CartProductReadDto
	{
		public int ShoppingCartId { get; set; }
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public int Quantity { get; set; }
	}
}

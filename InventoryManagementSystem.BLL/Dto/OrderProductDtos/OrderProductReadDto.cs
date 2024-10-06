
namespace InventoryManagementSystem.BLL.Dto.OrderProductDtos
{
	public class OrderProductReadDto
	{
		public int OrderId { get; set; }          
		public int ProductId { get; set; }          
		public string ProductName { get; set; }    
		public int Quantity { get; set; }           
		public double PriceAtPurchase { get; set; }
	}
}

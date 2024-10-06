namespace InventoryManagementSystem.BLL.Dto.OrderProductDtos
{
	public class OrderProductAddDto
	{
		public int OrderId { get; set; }          
		public int ProductId { get; set; }         
		public int Quantity { get; set; }          
		public double PriceAtPurchase { get; set; }
	}
}

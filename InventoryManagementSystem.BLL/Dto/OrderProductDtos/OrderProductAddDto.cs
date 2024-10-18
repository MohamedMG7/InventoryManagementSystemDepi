namespace InventoryManagementSystem.BLL.Dto.OrderProductDtos
{
	public class OrderProductAddDto
	{          
		public int ProductVariantId { get; set; }
		public int Quantity { get; set; }          
		public double PriceAtPurchase { get; set; }
	}
}

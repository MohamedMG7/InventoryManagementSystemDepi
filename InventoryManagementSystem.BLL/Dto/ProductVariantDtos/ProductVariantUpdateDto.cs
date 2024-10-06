
namespace InventoryManagementSystem.BLL.Dto.ProductVariantDtos
{
	public class ProductVariantUpdateDto
	{
		public int ProductVariantId { get; set; }
		public int ProductId { get; set; }
		public string Size { get; set; }
		public string Color { get; set; }
		public int QuantityInStock { get; set; }
		public decimal Weight { get; set; }
		public string? Dimensions { get; set; }
	}
}

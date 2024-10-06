
using InventoryManagementSystem.DAL.Data.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace InventoryManagementSystem.BLL.Dto.ProductVariantDtos
{
	public class ProductVariantAddDto
	{
		public int ProductId { get; set; }
		public string Size { get; set; }
		public string Color { get; set; }
		public int QuantityInStock { get; set; }
		public decimal Weight { get; set; }
		public string? Dimensions { get; set; }
	}
}

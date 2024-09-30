namespace InventoryManagementSystem.BLL.Dto
{
	public class ProductAddDto
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public double Price { get; set; }
		public string ImageUrl { get; set; }

		public int CompanyId { get; set; }
		public int CategoryId { get; set; }

		public int? MinimumStockToRequest { get; set; }
		public int? DiscountPrecentage { get; set; }
	}
}

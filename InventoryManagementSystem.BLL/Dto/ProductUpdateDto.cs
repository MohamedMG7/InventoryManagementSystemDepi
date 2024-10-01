
namespace InventoryManagementSystem.BLL.Dto
{
    public class ProductUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public int? MinimumStockToRequest { get; set; }
        public int? DiscountPercentage { get; set; }
    }
}

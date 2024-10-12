
namespace InventoryManagementSystem.DAL.Data.Models
{
	public class CartProduct
	{
        public int ShoppingCartId { get; set; }
        public ShoppingCart shoppingCart { get; set; }

        public int ProductId { get; set; }
        public Product product { get; set; }

        public int Quantity { get; set; }
        public bool isDeleted { get; set; }
    }
}

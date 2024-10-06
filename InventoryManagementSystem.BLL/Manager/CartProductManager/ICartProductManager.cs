
using InventoryManagementSystem.BLL.Dto.CartProductDtos;

namespace InventoryManagementSystem.BLL.Manager.CartProductManager
{
	public interface ICartProductManager
	{
		IEnumerable<CartProductReadDto> GetAll();
		CartProductReadDto GetbyId(int ShoppingCartid, int ProductId);
		void Add(CartProductAddDto cartproductAddDto);
		void Update(CartProductUpdateDto cartproductupdatedto);
		void Delete(int ShoppingCartid, int ProductId);
		void SaveChanges();

		//there should be dto to get all the products in the shoppingcart
	}
}

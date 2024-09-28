
using InventoryManagementSystem.DAL.Data.Models;

namespace InventoryManagementSystem.DAL.Reposatiries
{
	public interface IShoppingCartRepo
	{
		IEnumerable<ShoppingCart> GetAll();
		ShoppingCart GetbyID(int id);
		void Delete(ShoppingCart ShoppingCart);
		void Update(ShoppingCart ShoppingCart);
		void Add(ShoppingCart ShoppingCart);
		void SaveChanges();
	}
}

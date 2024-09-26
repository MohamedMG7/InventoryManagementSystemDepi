using InventoryManagementSystem.DAL.Data.Models;

namespace InventoryManagementSystem.BLL.Manager
{
	public interface IProductManager
	{
		IEnumerable<Product> GetAll();
		Product GetbyId(int id);
		void Add(Product product);
		void Update(Product product);
		void Delete(int id);
		void SaveChanges();
	}
}

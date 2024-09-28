
using InventoryManagementSystem.DAL.Data.Models;

namespace InventoryManagementSystem.DAL.Reposatiries
{
	public interface ICategoryRepo
	{
		IEnumerable<Category> GetAll();
		Category GetbyID(int id);
		void Delete(Category Category);
		void Update(Category Category);
		void Add(Category Category);
		void SaveChanges();
	}
}

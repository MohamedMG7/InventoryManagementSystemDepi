using InventoryManagementSystem.BLL.Dto;
using InventoryManagementSystem.DAL.Data.Models;

namespace InventoryManagementSystem.BLL.Manager
{
	public interface IProductManager
	{
		IEnumerable<Product> GetAll();
		ProductReadDto GetbyId(int id);
		void Add(ProductAddDto productAddDto);
		void Update(Product product);
		void Delete(int id);
		void SaveChanges();
	}
}

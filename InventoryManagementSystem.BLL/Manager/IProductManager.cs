using InventoryManagementSystem.BLL.Dto;
using InventoryManagementSystem.DAL.Data.Models;

namespace InventoryManagementSystem.BLL.Manager
{
	public interface IProductManager
	{
		IEnumerable<ProductReadDto> GetAll();
		ProductReadDto GetbyId(int id);
		void Add(ProductAddDto productAddDto);
		void Update(ProductUpdateDto productupdatedto);
		void Delete(int id);
		void SaveChanges();
	}
}

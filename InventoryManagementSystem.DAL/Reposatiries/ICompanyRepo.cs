using InventoryManagementSystem.DAL.Data.Models;

namespace InventoryManagementSystem.DAL.Reposatiries
{
	public interface ICompanyRepo
	{
		IEnumerable<Company> GetAll();
		Company GetbyID(int id);
		void Delete(Company Company);
		void Update(Company Company);
		void Add(Company Company);
		void SaveChanges();
	}
}

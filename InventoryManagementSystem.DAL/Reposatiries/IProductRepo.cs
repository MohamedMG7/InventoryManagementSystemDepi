
using InventoryManagementSystem.DAL.Data.Models;


namespace InventoryManagementSystem.DAL.Reposatiries
{
	public interface IProductRepo
	{
		IEnumerable<Product> GetAll();
		Product GetbyID(int id);
        void Delete(Product product);
		void Update(Product product);
		void Add(Product product);
		void SaveChanges();
        IEnumerable<Product> GetProductsByCategory(int categoryId);

    }
}


using InventoryManagementSystem.DAL.Data.Models;

namespace InventoryManagementSystem.DAL.Reposatiries
{
	public interface IOrderRepo
	{
		IEnumerable<Order> GetAll();
		Order GetbyID(int id);
		void Delete(Order order);
		void Update(Order order);
		void Add(Order order);
		void SaveChanges();
	}
}

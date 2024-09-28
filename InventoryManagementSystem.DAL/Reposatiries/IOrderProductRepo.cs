

using InventoryManagementSystem.DAL.Data.Models;

namespace InventoryManagementSystem.DAL.Reposatiries
{
	public interface IOrderProductRepo
	{
		IEnumerable<OrderProduct> GetAll();
		OrderProduct GetbyID(int id);
		void Delete(OrderProduct OrderProduct);
		void Update(OrderProduct OrderProduct);
		void Add(OrderProduct OrderProduct);
		void SaveChanges();
	}
}

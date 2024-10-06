

using InventoryManagementSystem.DAL.Data.Models;

namespace InventoryManagementSystem.DAL.Reposatiries
{
	public interface IOrderProductRepo
	{
		IEnumerable<OrderProduct> GetAll();
		OrderProduct GetbyID(int Orderid, int ProductId);
		void Delete(OrderProduct OrderProduct);
		void Update(OrderProduct OrderProduct);
		void Add(OrderProduct OrderProduct);
		//Order GetOrderWithProducts(int orderId);
		void SaveChanges();
	}
}

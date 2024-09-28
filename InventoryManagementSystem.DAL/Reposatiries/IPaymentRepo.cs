using InventoryManagementSystem.DAL.Data.Models;

namespace InventoryManagementSystem.DAL.Reposatiries
{
	public interface IPaymentRepo
	{
		IEnumerable<Payment> GetAll();
		Payment GetbyID(int id);
		void Delete(Payment payment);
		void Update(Payment payment);
		void Add(Payment payment);
		void SaveChanges();
	}
}

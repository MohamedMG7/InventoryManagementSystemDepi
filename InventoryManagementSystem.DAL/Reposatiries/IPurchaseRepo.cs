using InventoryManagementSystem.DAL.Data.Models;

namespace InventoryManagementSystem.DAL.Reposatiries
{
	public interface IPurchaseRepo
	{
		IEnumerable<Purchase> GetAll();
		Purchase GetbyID(int id);
		void Delete(Purchase Purchase);
		void Update(Purchase Purchase);
		void Add(Purchase Purchase);
		void SaveChanges();
		IEnumerable<Purchase> GetAllPurchasesWithProducts();
	}
}

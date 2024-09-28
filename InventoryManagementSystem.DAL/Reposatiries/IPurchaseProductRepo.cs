using InventoryManagementSystem.DAL.Data.Models;

namespace InventoryManagementSystem.DAL.Reposatiries
{
	public interface IPurchaseProductRepo
	{
		IEnumerable<PurchaseProduct> GetAll();
		PurchaseProduct GetbyID(int id);
		void Delete(PurchaseProduct PurchaseProduct);
		void Update(PurchaseProduct PurchaseProduct);
		void Add(PurchaseProduct PurchaseProduct);
		void SaveChanges();
	}
}

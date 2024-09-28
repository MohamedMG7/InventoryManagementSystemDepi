using InventoryManagementSystem.DAL.Data.DbHelper;
using InventoryManagementSystem.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.DAL.Reposatiries
{
	public class PurchaseRepo : IPurchaseRepo
	{
		private readonly InventoryManagementSystemContext _context;
		public PurchaseRepo(InventoryManagementSystemContext context)
		{
			_context = context;
		}
		public void Add(Purchase Purchase)
		{
			_context.Purchases.Add(Purchase);
		}

		public void Delete(Purchase Purchase)
		{
			_context.Purchases.Remove(Purchase);
		}

		public IEnumerable<Purchase> GetAll()
		{
			return _context.Purchases.AsNoTracking().ToList();
		}

		public Purchase GetbyID(int id)
		{
			return _context.Purchases.Find(id);
		}

		public void SaveChanges()
		{
			_context.SaveChanges();
		}

		public void Update(Purchase Purchase)
		{
			
		}
	}
}

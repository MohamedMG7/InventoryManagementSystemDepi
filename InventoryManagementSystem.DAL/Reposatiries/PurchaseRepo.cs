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
			if (Purchase != null)
			{
				Purchase.isDeleted = true;
			}
		}

		public IEnumerable<Purchase> GetAll()
		{
			return _context.Purchases.AsNoTracking().ToList();
		}

		public IEnumerable<Purchase> GetAllPurchasesWithProducts()
		{
			return _context.Purchases
				.Include(p => p.purchaseProducts)
					.ThenInclude(pp => pp.ProductVariant)
						.ThenInclude(pv => pv.product)
							.ThenInclude(p => p.company)
				.ToList();
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

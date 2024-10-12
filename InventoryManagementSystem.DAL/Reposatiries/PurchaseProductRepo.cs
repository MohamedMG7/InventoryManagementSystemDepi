
using InventoryManagementSystem.DAL.Data.DbHelper;
using InventoryManagementSystem.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.DAL.Reposatiries
{
	public class PurchaseProductRepo : IPurchaseProductRepo
	{
		private readonly InventoryManagementSystemContext _context;
		public PurchaseProductRepo(InventoryManagementSystemContext context)
		{
			_context = context;
		}

		public void Add(PurchaseProduct PurchaseProduct)
		{
			_context.PurchaseProducts.Add(PurchaseProduct);
		}

		public void Delete(PurchaseProduct PurchaseProduct)
		{
			if (PurchaseProduct != null) { 
				PurchaseProduct.isDeleted = true;
			}
		}

		public IEnumerable<PurchaseProduct> GetAll()
		{
			return _context.PurchaseProducts.AsNoTracking().ToList();
		}

		public PurchaseProduct GetbyID(int id)
		{
			return _context.PurchaseProducts.Find(id);
		}

		public void SaveChanges()
		{
			_context.SaveChanges();
		}

		public void Update(PurchaseProduct PurchaseProduct)
		{
			
		}
	}
}

using InventoryManagementSystem.DAL.Data.DbHelper;
using InventoryManagementSystem.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace InventoryManagementSystem.DAL.Reposatiries
{
	public class ShoppingCartRepo : IShoppingCartRepo
	{
		private readonly InventoryManagementSystemContext _context;
		public ShoppingCartRepo(InventoryManagementSystemContext context)
		{
			_context = context;
		}
		public void Add(ShoppingCart ShoppingCart)
		{
			_context.ShoppingCarts.Add(ShoppingCart);
		}

		public void Delete(ShoppingCart ShoppingCart)
		{
			_context.ShoppingCarts.Remove(ShoppingCart);
		}

		public IEnumerable<ShoppingCart> GetAll()
		{
			return _context.ShoppingCarts.AsNoTracking().ToList();
		}

		public ShoppingCart GetbyID(int id)
		{
			return _context.ShoppingCarts.Find(id);
		}

		public void SaveChanges()
		{
			_context.SaveChanges();
		}

		public void Update(ShoppingCart ShoppingCart)
		{
			
		}
	}
}

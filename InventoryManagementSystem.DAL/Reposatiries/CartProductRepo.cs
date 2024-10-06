

using InventoryManagementSystem.DAL.Data.DbHelper;
using InventoryManagementSystem.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.DAL.Reposatiries
{
	public class CartProductRepo : ICartProductRepo
	{
		private readonly InventoryManagementSystemContext _context;
		public CartProductRepo(InventoryManagementSystemContext context)
		{
			_context = context;
		}
		public void Add(CartProduct CartProduct)
		{
			_context.cartProducts.Add(CartProduct);
		}

		public void Delete(CartProduct CartProduct)
		{
			_context.cartProducts.Remove(CartProduct);
		}

		public IEnumerable<CartProduct> GetAll()
		{
			return _context.cartProducts.Include(op => op.product).AsNoTracking().ToList();
		}

		public CartProduct GetbyID(int ShoppingCartid, int ProductId)
		{
			return _context.cartProducts.Include(op => op.product).FirstOrDefault(op => op.ProductId == ProductId && op.ShoppingCartId == ShoppingCartid);
		}

		public void SaveChanges()
		{
			_context.SaveChanges();
		}

		public void Update(CartProduct CartProduct)
		{
			
		}
	}
}

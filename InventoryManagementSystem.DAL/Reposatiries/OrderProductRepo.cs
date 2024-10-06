

using InventoryManagementSystem.DAL.Data.DbHelper;
using InventoryManagementSystem.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.DAL.Reposatiries
{
	public class OrderProductRepo : IOrderProductRepo
	{
		private readonly InventoryManagementSystemContext _context;
		public OrderProductRepo(InventoryManagementSystemContext context)
		{
			_context = context;
		}
		public void Add(OrderProduct OrderProduct)
		{
			_context.orderProducts.Add(OrderProduct);
		}

		public void Delete(OrderProduct OrderProduct)
		{
			_context.orderProducts.Remove(OrderProduct);
		}

		public IEnumerable<OrderProduct> GetAll()
		{
			return _context.orderProducts.Include(op => op.product).AsNoTracking().ToList();
		}

		public OrderProduct GetbyID(int Orderid,int ProductId)
		{
			return _context.orderProducts.Include(op => op.product).FirstOrDefault(op => op.OrderId == Orderid && op.ProductId == ProductId);
		}

		public void SaveChanges()
		{
			_context.SaveChanges();
		}

		public void Update(OrderProduct OrderProduct)
		{
			
		}
	}
}



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
			if (OrderProduct != null)
			{
				OrderProduct.isDeleted = true;
			}
		}

		public IEnumerable<OrderProduct> GetAll()
		{
			return _context.orderProducts.Include(op => op.ProductVariant).AsNoTracking().ToList();
		}

		public OrderProduct GetbyID(int Orderid,int ProductId)
		{
			return _context.orderProducts.Include(op => op.ProductVariant).FirstOrDefault(op => op.OrderId == Orderid && op.ProductVariantId == ProductId);
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

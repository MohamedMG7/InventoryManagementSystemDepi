using InventoryManagementSystem.DAL.Data.DbHelper;
using InventoryManagementSystem.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.DAL.Reposatiries
{
	public class OrderRepo : IOrderRepo
	{
		private readonly InventoryManagementSystemContext _context;
        public OrderRepo(InventoryManagementSystemContext context)
        {
			_context = context;
        }
        public void Add(Order order)
		{
			_context.Orders.Add(order);
		}

		public void Delete(Order order)
		{
			_context.Orders.Remove(order);
		}

		public IEnumerable<Order> GetAll()
		{
			return _context.Orders.AsNoTracking().ToList();
		}

		public Order GetbyID(int id)
		{
			return _context.Orders.Find(id);
		}

		public void SaveChanges()
		{
			_context.SaveChanges();
		}

		public void Update(Order order)
		{
			
		}
	}
}

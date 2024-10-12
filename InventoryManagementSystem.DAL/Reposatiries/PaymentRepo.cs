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
	public class PaymentRepo : IPaymentRepo
	{
		private readonly InventoryManagementSystemContext _context;
        public PaymentRepo(InventoryManagementSystemContext context)
        {
            _context = context;
        }
        public void Add(Payment payment)
		{
			_context.Payments.Add(payment);
		}

		public void Delete(Payment payment)
		{
			if (payment != null) { 
				payment.isDeleted = true;
			}
		}

		public IEnumerable<Payment> GetAll()
		{
			return _context.Payments.AsNoTracking().ToList();
		}

		public Payment GetbyID(int id)
		{
			return _context.Payments.Find(id);
		}

		public void SaveChanges()
		{
			_context.SaveChanges();
		}

		public void Update(Payment payment)
		{
			
		}
	}
}

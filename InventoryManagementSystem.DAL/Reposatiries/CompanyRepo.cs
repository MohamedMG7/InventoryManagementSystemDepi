

using InventoryManagementSystem.DAL.Data.DbHelper;
using InventoryManagementSystem.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.DAL.Reposatiries
{
	public class CompanyRepo : ICompanyRepo
	{
		private readonly InventoryManagementSystemContext _context;
		public CompanyRepo(InventoryManagementSystemContext context)
		{
			_context = context;
		}
		public void Add(Company Company)
		{
			_context.Company.Add(Company);
		}

		public void Delete(Company Company)
		{
			if (Company != null) { 
				Company.isDeleted = true;
			}
		}

		public IEnumerable<Company> GetAll()
		{
			return _context.Company.AsNoTracking().ToList();
		}

		public Company GetbyID(int id)
		{
			return _context.Company.Find(id);
		}

		public void SaveChanges()
		{
			_context.SaveChanges();
		}

		public void Update(Company Company)
		{
			
		}
	}
}

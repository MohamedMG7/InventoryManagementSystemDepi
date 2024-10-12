using InventoryManagementSystem.DAL.Data.DbHelper;
using InventoryManagementSystem.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace InventoryManagementSystem.DAL.Reposatiries
{
	public class CategoryRepo : ICategoryRepo
	{
		private readonly InventoryManagementSystemContext _context;
		public CategoryRepo(InventoryManagementSystemContext context)
		{
			_context = context;
		}
		public void Add(Category Category)
		{
			_context.Category.Add(Category);
		}

		public void Delete(Category Category)
		{
			if (Category != null) { 
				Category.isDeleted = true;
			}
		}

		public IEnumerable<Category> GetAll()
		{
			return _context.Category.AsNoTracking().ToList();
		}

		public Category GetbyID(int id)
		{
			return _context.Category.Find(id);
		}

		public void SaveChanges()
		{
			_context.SaveChanges();
		}

		public void Update(Category Category)
		{
			
		}
	}
}

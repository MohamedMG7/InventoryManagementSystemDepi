using InventoryManagementSystem.DAL.Data.DbHelper;
using InventoryManagementSystem.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.DAL.Reposatiries
{
	public class ProductRepo : IProductRepo
	{
		private readonly InventoryManagementSystemContext _context;
        public ProductRepo(InventoryManagementSystemContext context)
        {
			_context = context;
        }
        public void Add(Product product)
		{
			_context.Products.Add(product);
		}

		public void Delete(Product product)
		{
			if (product != null)
			{
				product.isDeleted = true; // it will get updated automatically in the manger when we save changes
			}
		}

		public IEnumerable<Product> GetAll()
		{
			return _context.Products.Include(p => p.company).Include(p => p.category).AsNoTracking().ToList();
		}

		public Product GetbyID(int id)
		{
			return _context.Products.Include(p => p.company).Include(p => p.category).FirstOrDefault(p => p.ProductId == id);
		}

		public void SaveChanges()
		{
			_context.SaveChanges();
		}

		public void Update(Product product)
		{
			//This Can be empty because and get handled in the BLL as long as the Entity is tracked by the EF
		}


        public IEnumerable<Product> GetProductsByCategory(int categoryId)
        {
            return _context.Products.Where(p => p.CategoryId == categoryId).ToList();
        }
    }
}

using InventoryManagementSystem.DAL.Data.Models;

namespace InventoryManagementSystem.DAL.Reposatiries
{
	public interface IProductVariantRepo
	{
		IEnumerable<ProductVariant> GetAll();
		ProductVariant GetbyID(int id);
		void Delete(ProductVariant ProductVariant);
		void Update(ProductVariant ProductVariant);
		void Add(ProductVariant ProductVariant);
		void SaveChanges();
	}
}

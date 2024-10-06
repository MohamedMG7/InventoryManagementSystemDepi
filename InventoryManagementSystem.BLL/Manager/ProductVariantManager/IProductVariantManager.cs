
using InventoryManagementSystem.BLL.Dto.ProductVariantDtos;

namespace InventoryManagementSystem.BLL.Manager.ProductVariantManager
{
	public interface IProductVariantManager
	{
		IEnumerable<ProductVariantReadDto> GetAll();
		ProductVariantReadDto GetbyId(int id);
		void Add(ProductVariantAddDto productVariantAddDto);
		void Update(ProductVariantUpdateDto productvariantupdatedto);
		void Delete(int id);
		void SaveChanges();
	}
}

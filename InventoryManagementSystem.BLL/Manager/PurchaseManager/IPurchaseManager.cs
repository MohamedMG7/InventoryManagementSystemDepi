using InventoryManagementSystem.BLL.Dto.PurchaseProductDtos;
using InventoryManagementSystem.BLL.Dto.PurchaseDtos;

namespace InventoryManagementSystem.BLL.Manager.PurchaseManager
{
	public interface IPurchaseManager
	{
		IEnumerable<PurchaseReadDto> GetAll();
		PurchaseReadDto GetbyId(int id);
		void Add(PurchaseAddDto purchaseAddDto);
		void Delete(int id);
		void SaveChanges();
		IEnumerable<PurchaseWithProductsReadDto> GetAllPurchasesWithProducts();
	}
}

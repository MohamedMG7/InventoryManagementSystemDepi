using InventoryManagementSystem.BLL.Dto.PurchaseDtos;
using InventoryManagementSystem.BLL.Dto.PurchaseProductDtos;


namespace InventoryManagementSystem.BLL.Manager.PurchaseProductManager
{
	public interface IPurchaseProductManager
	{
		IEnumerable<PurchaseProductReadDto> GetAll();
		PurchaseProductReadDto GetbyId(int Purchaseid, int ProductId);
		void Add(PurchaseProductAddDto purchaseproductAddDto);
		//void Update(PurchaseProductUpdateDto purchaseproductupdatedto);
		void Delete(int PurchaseId, int ProductId);
		void SaveChanges();
	}
}

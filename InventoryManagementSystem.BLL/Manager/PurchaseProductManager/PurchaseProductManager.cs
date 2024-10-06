
using InventoryManagementSystem.BLL.Dto.CartProductDtos;
using InventoryManagementSystem.BLL.Dto.PurchaseProductDtos;
using InventoryManagementSystem.DAL.Data.Models;
using InventoryManagementSystem.DAL.Reposatiries;

namespace InventoryManagementSystem.BLL.Manager.PurchaseProductManager
{
	public class PurchaseProductManager : IPurchaseProductManager
	{
		private readonly IPurchaseProductRepo _purchaseProductRepo;
        public PurchaseProductManager(IPurchaseProductRepo purchaseProductRepo)
        {
            _purchaseProductRepo = purchaseProductRepo;
        }
        public void Add(PurchaseProductAddDto purchaseproductAddDto)
		{
			var purchaseProductModel = new PurchaseProduct { 
				ProductVariantId = purchaseproductAddDto.ProductVariantId,
				PurchaseId = purchaseproductAddDto.PurchaseId,
				QuantityPurchased = purchaseproductAddDto.QuantityPurchased,
				UnitCost = purchaseproductAddDto.UnitCost,
				TotalCost = purchaseproductAddDto.TotalCost,
				
			};

			_purchaseProductRepo.Add(purchaseProductModel);
			_purchaseProductRepo.SaveChanges();
		}

		public void Delete(int PurchaseId, int ProductId)
		{
			var purchaseProductModel = _purchaseProductRepo.GetbyID(PurchaseId, ProductId);
			_purchaseProductRepo.Delete(purchaseProductModel);
			_purchaseProductRepo.SaveChanges();
		}

		public IEnumerable<PurchaseProductReadDto> GetAll()
		{
			var purchaseProducts = _purchaseProductRepo.GetAll();
			var purchaseProductsList = purchaseProducts.Select(x => new PurchaseProductReadDto
			{
				ProductVariantId = x.ProductVariantId,
				PurchaseId = x.PurchaseId,
				TotalCost = x.TotalCost,
				UnitCost = x.UnitCost,
				//ProductVariantName = x.ProductVariant.product.Name,
				PurchaseProductId = x.PurchaseProductId,
				QuantityPurchased= x.QuantityPurchased

			});
			return purchaseProductsList;
		}

		public PurchaseProductReadDto GetbyId(int Purchaseid, int ProductId)
		{
			var purchaseProductsModel = _purchaseProductRepo.GetbyID(Purchaseid, ProductId);
			PurchaseProductReadDto purchaseProductReadDto = new PurchaseProductReadDto
			{
				ProductVariantId = purchaseProductsModel.ProductVariantId,
				PurchaseId = purchaseProductsModel.PurchaseId,
				TotalCost = purchaseProductsModel.TotalCost,
				UnitCost = purchaseProductsModel.UnitCost,
				ProductVariantName = purchaseProductsModel.ProductVariant.product.Name,
				PurchaseProductId = purchaseProductsModel.PurchaseProductId,
				QuantityPurchased = purchaseProductsModel.QuantityPurchased
			};

			return purchaseProductReadDto;
		}

		public void SaveChanges()
		{
			_purchaseProductRepo.SaveChanges();
		}
	}
}

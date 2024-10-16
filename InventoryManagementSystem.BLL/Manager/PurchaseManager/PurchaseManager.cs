
using InventoryManagementSystem.BLL.Dto.PurchaseDtos;
using InventoryManagementSystem.DAL.Reposatiries;
using InventoryManagementSystem.DAL.Data.Models;
using InventoryManagementSystem.BLL.Dto.OrderDtos;

namespace InventoryManagementSystem.BLL.Manager.PurchaseManager
{
	public class PurchaseManager : IPurchaseManager
	{
		private readonly IPurchaseRepo _purchaseRepo;
        public PurchaseManager(IPurchaseRepo purchaseRepo)
        {
            _purchaseRepo = purchaseRepo;
        }
        public void Add(PurchaseAddDto purchaseAddDto)
		{
			var purchaseModel = new Purchase {
				Notes = purchaseAddDto.Notes,
				PaymentMethod = purchaseAddDto.PaymentMethod,
				purchaseProducts = new List<PurchaseProduct>()
			};

			foreach (var purchaseProductDto in purchaseAddDto.Products)
			{
				var purchaseProduct = new PurchaseProduct
				{
					// Set the OrderId to associate this product with the order
					ProductVariantId = purchaseProductDto.ProductVariantId,
					UnitCost = purchaseProductDto.UnitCost,
					QuantityPurchased = purchaseProductDto.QuantityPurchased,
					TotalCost = purchaseProductDto.UnitCost * purchaseProductDto.QuantityPurchased,
				};

				purchaseModel.purchaseProducts.Add(purchaseProduct);
			}

			purchaseModel.TotalCost = purchaseModel.purchaseProducts.Sum(pp => pp.TotalCost);

			purchaseModel.DateTime = DateTime.Now; 
			_purchaseRepo.Add(purchaseModel);
			_purchaseRepo.SaveChanges();

			foreach (var purchaseProduct in purchaseModel.purchaseProducts)
			{
				purchaseProduct.PurchaseId = purchaseModel.PurchaseId;
			}
		}

		public void Delete(int id)
		{
			var purchaseModel = _purchaseRepo.GetbyID(id);
			if (purchaseModel != null && !purchaseModel.isDeleted) {
				_purchaseRepo.Delete(purchaseModel);
				_purchaseRepo.SaveChanges();
			}
			
		}

		public IEnumerable<PurchaseReadDto> GetAll()
		{
			var purchaseModels = _purchaseRepo.GetAll();
			var purchaseList = purchaseModels.Select(x => new PurchaseReadDto {
				TotalCost=x.TotalCost,
				Notes=x.Notes,
				PaymentMethod = x.PaymentMethod,
				DateTime = x.DateTime,
				PurchaseId = x.PurchaseId,
			});
			return purchaseList;
		}

		public PurchaseReadDto GetbyId(int id)
		{
			var purchaseModel = _purchaseRepo.GetbyID(id);
			PurchaseReadDto purchase = new PurchaseReadDto { 
				PurchaseId=purchaseModel.PurchaseId,
				TotalCost=purchaseModel.TotalCost,
				Notes=purchaseModel.Notes,
				PaymentMethod = purchaseModel.PaymentMethod,
				DateTime = purchaseModel.DateTime,
			};
			return purchase;
		}

		public void SaveChanges()
		{
			_purchaseRepo.SaveChanges();
		}
	}
}

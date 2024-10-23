
using InventoryManagementSystem.BLL.Dto.PurchaseDtos;
using InventoryManagementSystem.DAL.Reposatiries;
using InventoryManagementSystem.DAL.Data.Models;
using InventoryManagementSystem.BLL.Dto.OrderDtos;
using InventoryManagementSystem.BLL.Dto.PurchaseProductDtos;

namespace InventoryManagementSystem.BLL.Manager.PurchaseManager
{
	public class PurchaseManager : IPurchaseManager
	{
		private readonly IPurchaseRepo _purchaseRepo;
		private readonly IProductVariantRepo _productVariantRepo;
		
		public PurchaseManager(IPurchaseRepo purchaseRepo, IProductVariantRepo productVariantRepo)
        {
            _purchaseRepo = purchaseRepo;
			_productVariantRepo = productVariantRepo;
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
			//_purchaseRepo.SaveChanges(); just save changes once to keep atomicity all or none // Implicit vs. Explicit Transaction Management


			foreach (var purchaseProduct in purchaseModel.purchaseProducts)
			{
				purchaseProduct.PurchaseId = purchaseModel.PurchaseId;
			}

			
			foreach (var purchaseProduct in purchaseModel.purchaseProducts)
			{
				
				var productVariant = _productVariantRepo.GetbyID(purchaseProduct.ProductVariantId);

				if (productVariant != null)
				{
					productVariant.QuantityInStock += purchaseProduct.QuantityPurchased;
					_productVariantRepo.Update(productVariant);
				}
			}
			_purchaseRepo.SaveChanges();
			// explicit transaction.begin / transaciton.commit / transaction.rollback 
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

		public IEnumerable<PurchaseWithProductsReadDto> GetAllPurchasesWithProducts()
		{
			var purchases = _purchaseRepo.GetAllPurchasesWithProducts(); // Call the DAL function

			var purchaseList = purchases.Select(p => new PurchaseWithProductsReadDto
			{
				PurchaseId = p.PurchaseId,
				DateTime = p.DateTime,
				TotalCost = p.TotalCost,
				Notes = p.Notes,
				PaymentMethod = p.PaymentMethod,
				Products = p.purchaseProducts.Select(pp => new PurhcaseProductReadDto
				{
					PurchaseId = pp.PurchaseId,
					ProductVariantId = pp.ProductVariantId,
					ProductName = pp.ProductVariant.product.Name,
					ProductProviderName = pp.ProductVariant.product.company.Name,
					QuantityPurchased = pp.QuantityPurchased,
					UnitCost = pp.UnitCost,
					TotalCost = pp.TotalCost
				}).ToList()
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

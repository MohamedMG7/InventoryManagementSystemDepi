
using InventoryManagementSystem.BLL.Dto.PurchaseDtos;
using InventoryManagementSystem.DAL.Reposatiries;
using InventoryManagementSystem.DAL.Data.Models;

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
				TotalCost = purchaseAddDto.TotalCost,
				Notes = purchaseAddDto.Notes,
				PaymentMethod = purchaseAddDto.PaymentMethod
			};

			purchaseModel.DateTime = DateTime.Now; 
			_purchaseRepo.Add(purchaseModel);
			_purchaseRepo.SaveChanges();
		}

		public void Delete(int id)
		{
			var purchaseModel = _purchaseRepo.GetbyID(id);
			_purchaseRepo.Delete(purchaseModel);
			_purchaseRepo.SaveChanges();
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

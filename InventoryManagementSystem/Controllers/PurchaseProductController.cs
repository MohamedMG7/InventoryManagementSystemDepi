using InventoryManagementSystem.BLL.Dto.PurchaseProductDtos;
using InventoryManagementSystem.BLL.Manager.PurchaseProductManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PurchaseProductController : ControllerBase
	{
		private readonly IPurchaseProductManager _purchaseProductManager;
		public PurchaseProductController(IPurchaseProductManager purchaseProductManager)
		{
			_purchaseProductManager = purchaseProductManager;
		}

		[HttpGet]
		public ActionResult<IEnumerable<PurchaseProductReadDto>> GetAll()
		{
			return Ok(_purchaseProductManager.GetAll());
		}

		[HttpGet]
		[Route("{PurchaseId}/{ProductId}")]
		public ActionResult GetById(int PurchaseId, int ProductId)
		{
			return Ok(_purchaseProductManager.GetbyId(PurchaseId, ProductId));
		}

		[HttpDelete]
		[Route("{PurchaseId}/{ProductId}")]
		public ActionResult DeleteById(int PurchaseId, int ProductId)
		{
			_purchaseProductManager.Delete(PurchaseId, ProductId);
			return NoContent();
		}

		[HttpPost]
		public ActionResult Add(PurchaseProductAddDto purchaseProductAddDto)
		{
			_purchaseProductManager.Add(purchaseProductAddDto);
			return Ok(purchaseProductAddDto);

		}
	}
}

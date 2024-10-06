using InventoryManagementSystem.BLL.Dto.PurchaseDtos;
using InventoryManagementSystem.BLL.Manager.PurchaseManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PurchaseController : ControllerBase
	{
		private readonly IPurchaseManager _purchaseManager;
		public PurchaseController(IPurchaseManager purchaseManager)
		{
			_purchaseManager = purchaseManager;
		}

		[HttpGet]
		public ActionResult<IEnumerable<PurchaseReadDto>> GetAll()
		{
			return Ok(_purchaseManager.GetAll());
		}

		[HttpGet]
		[Route("{id}")]
		public ActionResult GetById(int id)
		{
			return Ok(_purchaseManager.GetbyId(id));
		}


		[HttpDelete]
		[Route("{id}")]
		public ActionResult DeleteById(int id)
		{
			_purchaseManager.Delete(id);
			return NoContent();
		}

		[HttpPost]
		public ActionResult Add(PurchaseAddDto purchaseAddDto)
		{
			_purchaseManager.Add(purchaseAddDto);
			return Ok(purchaseAddDto);
		}
	}
}

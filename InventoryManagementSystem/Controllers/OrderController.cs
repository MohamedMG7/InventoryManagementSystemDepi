using InventoryManagementSystem.BLL.Dto.OrderDtos;
using InventoryManagementSystem.BLL.Manager.OrderManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly IOrderManager _orderManager;
		public OrderController(IOrderManager orderManager)
		{
			_orderManager = orderManager;
		}

		[HttpGet]
		public ActionResult<IEnumerable<OrderReadDto>> GetAll()
		{
			return Ok(_orderManager.GetAll());
		}

		[HttpGet]
		[Route("{id}")]
		public ActionResult GetById(int id)
		{
			return Ok(_orderManager.GetbyId(id));
		}

		[HttpDelete]
		[Route("{id}")]
		public ActionResult DeleteById(int id)
		{
			_orderManager.Delete(id);
			return NoContent();
		}

		[HttpPost]
		public ActionResult Add(OrderAddDto orderAddDto)
		{
			_orderManager.Add(orderAddDto);
			return Ok(orderAddDto);

		}
	}
}

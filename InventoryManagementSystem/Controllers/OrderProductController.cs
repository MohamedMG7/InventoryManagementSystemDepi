using InventoryManagementSystem.BLL.Dto.OrderProductDtos;
using InventoryManagementSystem.BLL.Manager.OrderProductManager;
using InventoryManagementSystem.DAL.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderProductController : ControllerBase
	{
		private readonly IOrderProductManager _orderProductManager;
		public OrderProductController(IOrderProductManager orderProductManager)
		{
			_orderProductManager = orderProductManager;
		}

		[HttpGet]
		public ActionResult<IEnumerable<OrderProductReadDto>> GetAll()
		{
			return Ok(_orderProductManager.GetAll());
		}

		[HttpGet]
		[Route("{OrderId}/{ProductId}")]
		public ActionResult GetById(int OrderId, int ProductId)
		{
			return Ok(_orderProductManager.GetbyId(OrderId,ProductId));
		}

		[HttpDelete]
		[Route("{OrderId}/{ProductId}")]
		public ActionResult DeleteById(int OrderId, int ProductId)
		{
			_orderProductManager.Delete(OrderId, ProductId);
			return NoContent();
		}

		[HttpPost]
		public ActionResult Add(OrderProductAddDto orderProductAddDto)
		{
			_orderProductManager.Add(orderProductAddDto);
			return Ok(orderProductAddDto);

		}
	}
}

using InventoryManagementSystem.BLL.Dto.OrderDtos;
using InventoryManagementSystem.BLL.Dto.PaymentDtos;
using InventoryManagementSystem.BLL.Manager.OrderManager;
using InventoryManagementSystem.BLL.Manager.PaymentManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly IOrderManager _orderManager;
		private readonly IPaymentManager _paymentManager;
		public OrderController(IOrderManager orderManager, IPaymentManager paymentManager)
		{
			_orderManager = orderManager;
			_paymentManager = paymentManager;
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
		//[Authorize(Roles = "User")]
		public ActionResult Add(OrderAddDto orderAddDto)
		{
			_orderManager.Add(orderAddDto);
			return Ok();

		}

		//[HttpGet("with-products/{orderId}")]
		//public ActionResult<ReadOrderWithProductsDto> GetOrderWithProductsData(int orderId)
		//{
		//		var orderWithProducts = _orderManager.GetOrderWithProductsData(orderId);
		//		return Ok(orderWithProducts);
		//}
	}
}

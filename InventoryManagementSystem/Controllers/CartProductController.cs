using InventoryManagementSystem.BLL.Dto.CartProductDtos;
using InventoryManagementSystem.BLL.Manager.CartProductManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CartProductController : ControllerBase
	{
		private readonly ICartProductManager _cartProductManager;
		public CartProductController(ICartProductManager cartProductManager)
		{
			_cartProductManager = cartProductManager;
		}

		[HttpGet]
		public ActionResult<IEnumerable<CartProductReadDto>> GetAll()
		{
			return Ok(_cartProductManager.GetAll());
		}

		[HttpGet]
		[Route("{OrderId}/{ProductId}")]
		public ActionResult GetById(int OrderId, int ProductId)
		{
			return Ok(_cartProductManager.GetbyId(OrderId, ProductId));
		}

		[HttpDelete]
		[Route("{OrderId}/{ProductId}")]
		public ActionResult DeleteById(int OrderId, int ProductId)
		{
			_cartProductManager.Delete(OrderId, ProductId);
			return NoContent();
		}

		[HttpPost]
		public ActionResult Add(CartProductAddDto cartProductAddDto)
		{
			_cartProductManager.Add(cartProductAddDto);
			return Ok(cartProductAddDto);

		}

		[HttpPut]
		[Route("{shoppingCartId}/{ProductId}")]
		public ActionResult Update(CartProductUpdateDto cartProductUpdateDto)
		{
			_cartProductManager.Update(cartProductUpdateDto);
			return NoContent();
		}
	}
}

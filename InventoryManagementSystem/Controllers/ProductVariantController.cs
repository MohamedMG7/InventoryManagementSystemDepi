using InventoryManagementSystem.BLL.Dto.ProductVariantDtos;
using InventoryManagementSystem.BLL.Manager.ProductVariantManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductVariantController : ControllerBase
	{
		private readonly IProductVariantManager _productVariantManager;
		public ProductVariantController(IProductVariantManager productVariantManager)
		{
			_productVariantManager = productVariantManager;
		}

		[HttpGet]
		public ActionResult<IEnumerable<ProductVariantReadDto>> GetAll()
		{
			return Ok(_productVariantManager.GetAll());
		}

		[HttpGet]
		[Route("{id}")]
		public ActionResult GetById(int id)
		{
			return Ok(_productVariantManager.GetbyId(id));
		}

		[HttpPut]
		[Route("{id}")]
		public ActionResult Update(int id, ProductVariantUpdateDto productVariantUpdateDto)
		{
			if (id != productVariantUpdateDto.ProductVariantId)
			{
				return BadRequest();
			}
			_productVariantManager.Update(productVariantUpdateDto);
			return Ok();
		}

		[HttpDelete]
		[Route("{id}")]
		public ActionResult DeleteById(int id)
		{
			_productVariantManager.Delete(id);
			return NoContent();
		}

		[HttpPost]
		public ActionResult Add(ProductVariantAddDto productAddDto)
		{
			_productVariantManager.Add(productAddDto);
			return Ok(productAddDto);

		}
	}
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InventoryManagementSystem.BLL.Manager;
using InventoryManagementSystem.BLL.Dto;

namespace InventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productManager;
        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductReadDto>> GetAll()
        {
            return Ok(_productManager.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(_productManager.GetbyId(id));
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Update(int id, ProductUpdateDto productUpdateDto)
        {
            if (id != productUpdateDto.Id) {
                return BadRequest();
            }
            _productManager.Update(productUpdateDto);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteById(int id)
        {
            _productManager.Delete(id);
            return NoContent();
        }

        [HttpPost]
        public ActionResult Add(ProductAddDto productAddDto) {
            _productManager.Add(productAddDto);
            return Ok(productAddDto);
        
        }
    }
}

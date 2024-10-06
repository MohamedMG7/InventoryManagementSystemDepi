using InventoryManagementSystem.BLL.Dto.CategoryDtos;
using InventoryManagementSystem.BLL.Manager.CategoryManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryManager _categoryManager;
        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryReadDto>> GetAll()
        {
            return Ok(_categoryManager.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(_categoryManager.GetbyId(id));
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Update(int id, CategoryUpdateDto categoryUpdateDto)
        {
            if (id != categoryUpdateDto.CategoryId)
            {
                return BadRequest();
            }
            _categoryManager.Update(categoryUpdateDto);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteById(int id)
        {
            _categoryManager.Delete(id);
            return NoContent();
        }

        [HttpPost]
        public ActionResult Add(CategoryAddDto productAddDto)
        {
            _categoryManager.Add(productAddDto);
            return Ok(productAddDto);

        }
    }
}

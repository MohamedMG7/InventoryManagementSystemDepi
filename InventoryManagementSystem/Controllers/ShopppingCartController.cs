using InventoryManagementSystem.BLL.Dto.ShoopinhCartDto;
using InventoryManagementSystem.BLL.Dto.UserDtos;
using InventoryManagementSystem.BLL.Manager.ShoppingCartManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopppingCartController : ControllerBase
    {
        private readonly IShoppingCartManger _shoppingCartManager;
        public ShopppingCartController(IShoppingCartManger shoppingCartManager)
        {
            _shoppingCartManager = shoppingCartManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ShoppingCartReadDto>> GetAll()
        {
            return Ok(_shoppingCartManager.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(_shoppingCartManager.GetbyId(id));
        }


        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteById(int id)
        {
            _shoppingCartManager.Delete(id);
            return NoContent();
        }

        [HttpPost]
        public ActionResult Add(ShoppingCartAddDto shoppingCartAddDto)
        {
            _shoppingCartManager.Add(shoppingCartAddDto);
            return Ok(shoppingCartAddDto);
        }
    }
}

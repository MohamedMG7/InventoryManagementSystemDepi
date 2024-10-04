using InventoryManagementSystem.BLL.Dto;
using InventoryManagementSystem.BLL.Dto.UserDtos;
using InventoryManagementSystem.BLL.Manager.UserManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;
        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserReadDto>> GetAll()
        {
            return Ok(_userManager.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(_userManager.GetbyId(id));
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Update(int id, UserUpdateDto userUpdateDto)
        {
            if (id != userUpdateDto.Id)
            {
                return BadRequest();
            }
            _userManager.Update(userUpdateDto);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteById(int id)
        {
            _userManager.Delete(id);
            return NoContent();
        }

        [HttpPost]
        public ActionResult Add(UserAddDto userAddDto)
        {
            _userManager.Add(userAddDto);
            return Ok(userAddDto);
        }
    }
}

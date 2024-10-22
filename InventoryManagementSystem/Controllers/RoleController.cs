using InventoryManagementSystem.BLL.Manager.RoleManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles ="SuperAdmin")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleManager _roleManager;
        public RoleController(IRoleManager roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            var success = await _roleManager.CreateRoleAsync(roleName);
            if (success)
            {
                return Ok("Role created successfully.");
            }
            return BadRequest("Failed to create role or role already exists.");
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteRole(string roleName)
        {
            var success = await _roleManager.DeleteRoleAsync(roleName);
            if (success)
            {
                return Ok("Role deleted successfully.");
            }
            return BadRequest("Failed to delete role or role does not exist.");
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _roleManager.GetAllRolesAsync();
            return Ok(roles);
        }
    }
}

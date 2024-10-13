
using InventoryManagementSystem.BLL.Dto;
using InventoryManagementSystem.BLL.Manager.AccountManager;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class RolesController : Controller
    {

        private readonly IAccountManager _accountManager;

        public RolesController(IAccountManager accountManager)
        {
            _accountManager = accountManager;
        }

        [HttpGet]
        //public IActionResult New()
        //{
        //    return View();
        //}

        [HttpPost]
        [HttpPost]
        [Route("NewRole")]
        public async Task<IActionResult> New(RoleMnagerDto newRole)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await _accountManager.CreateRoleAsync(newRole);

                if (result.Succeeded)
                {
                    return Ok(result);
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return BadRequest(ModelState); 
                }
            }
            return BadRequest(ModelState); 
        }
    }
}

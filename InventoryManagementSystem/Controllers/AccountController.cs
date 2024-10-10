using InventoryManagementSystem.BLL.Dto.UserDtos;
using InventoryManagementSystem.BLL.Manager.AccountManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly IAccountManager _accountManager;

		public AccountController(IAccountManager accountManager)
		{
			_accountManager = accountManager;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] UserRegisterDto registerDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var result = await _accountManager.RegisterUser(registerDto);
			if (result.Succeeded)
			{
				return Ok(new { Message = "User registered successfully!" });
			}

			// Return the errors if the registration failed
			foreach (var error in result.Errors)
			{
				ModelState.AddModelError(string.Empty, error.Description);
			}
			return BadRequest(ModelState);
		}

	}
}

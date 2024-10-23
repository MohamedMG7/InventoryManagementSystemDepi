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
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
        {
			if (!ModelState.IsValid) 
			{
				return BadRequest(ModelState); 
			}

			var result = await _accountManager.LoginUser(loginDto,true);

			if (result.StartsWith("Invalid")) 
			{
				return BadRequest(new { Message = result }); 
			}

			return Ok(new { Token = result }); 
		}

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountManager.LogoutUser();
            return Ok(new { Message = "User logged out successfully!" });
        }
    }
}

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
                var roleResult = await _accountManager.AddRoleAsync(registerDto, "Admin");
                if (roleResult.Succeeded)
                {
                    return Ok(new { Message = "User registered and added to Admin role successfully!" });
                }
                else
                {
                    foreach (var error in roleResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return BadRequest(ModelState);
                }
            }
            // Return the errors if the registration failed
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return BadRequest(ModelState);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDto loginDto)
        {
            if (ModelState.IsValid) // Check if the model is valid
            {
                var result = await _accountManager.LoginUser(loginDto);

                if (result.Succeeded)
                {
                    return Ok(new { Message = "User logged in successfully!" });
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }

            return BadRequest(ModelState); // Return any validation errors
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountManager.LogoutUser();
            return Ok(new { Message = "User logged out successfully!" });
        }
    }
}

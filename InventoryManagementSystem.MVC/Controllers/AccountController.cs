using InventoryManagementSystem.BLL.Dto.UserDtos;
using InventoryManagementSystem.BLL.Manager.AccountManager;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InventoryManagementSystem.MVC.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        private readonly IAccountManager _accountManager;

        public AccountController(IAccountManager accountManager)
        {
            _accountManager = accountManager;
        }

        // GET: /account/login
        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /account/login
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto loginDto, bool rememberMe)
        {
            var result = await _accountManager.LoginUser(loginDto,rememberMe);

            if (result == "Login successful")
            {
                return RedirectToAction("Index", "Home"); // Redirect to Home after successful login
            }

            ModelState.AddModelError("", result); // Display error message if login fails
            return View(loginDto); // Stay on the login page
        }

        // GET: /account/register
        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /account/register
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto registerDto)
        {
            var result = await _accountManager.RegisterUser(registerDto);

            if (result.Succeeded)
            {
                return RedirectToAction("Login"); // Redirect to login after successful registration
            }

            // Display validation errors if registration fails
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(registerDto); // Stay on the registration page
        }

        // POST: /account/logout
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountManager.LogoutUser();
            return RedirectToAction("Login"); // Redirect to login after logout
        }
    }
}

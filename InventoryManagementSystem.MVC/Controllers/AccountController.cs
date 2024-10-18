using InventoryManagementSystem.BLL.Dto.UserDtos;
using InventoryManagementSystem.BLL.Manager.AccountManager;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountManager _accountManager;

        public AccountController(IAccountManager accountManager)
        {
            _accountManager = accountManager;
        }

        // Register action for MVC
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return View(registerDto); // Return the view with validation errors
            }

            var result = await _accountManager.RegisterUser(registerDto);
            if (result.Succeeded)
            {
                // Redirect to the login page or home page after successful registration
                return RedirectToAction("Login");
            }

            // Add the errors to the model state
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            // Return the view with errors
            return View(registerDto);
        }

        // Login action for MVC
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountManager.LoginUser(loginDto);

                if (result.Succeeded)
                {
                    // Redirect to the home page after successful login
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid username or password.");
                }
            }

            return View(loginDto); // Return the view with validation errors
        }

        // Logout action for MVC
        public async Task<IActionResult> Logout()
        {
            await _accountManager.LogoutUser();
            return RedirectToAction("Login"); // Redirect to the login page after logout
        }
    }
}

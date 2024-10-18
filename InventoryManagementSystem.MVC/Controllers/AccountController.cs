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

        // GET: Account/Register
        [HttpGet]
        [Route("Account/Register")]
        public IActionResult Register()
        {
            return View(); 
        }

        // POST: Account/Register
        [HttpPost]
        [Route("Account/Register")]
        public async Task<IActionResult> Register(UserRegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return View(registerDto); 
            }

            var result = await _accountManager.RegisterUser(registerDto);
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(registerDto);
        }

        // GET: Account/Login
        [HttpGet]
        [Route("Account/Login")]
        public IActionResult Login()
        {
            return View(); 
        }

        // POST: Account/Login
        [HttpPost]
        [Route("Account/Login")]
        public async Task<IActionResult> Login(UserLoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountManager.LoginUser(loginDto);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid username or password.");
                }
            }

            return View(loginDto); 
        }

        // POST: Account/Logout
        [HttpPost]
        [Route("Account/Logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountManager.LogoutUser();
            return RedirectToAction("Login");
        }
    }
}

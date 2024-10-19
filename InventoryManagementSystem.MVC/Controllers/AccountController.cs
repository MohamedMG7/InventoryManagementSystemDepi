using InventoryManagementSystem.BLL.Dto.UserDtos;
using InventoryManagementSystem.BLL.Manager.AccountManager;
using InventoryManagementSystem.DAL.Data.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountManager _accountManager;

        private readonly SignInManager<User> _signInManager;

        public AccountController(IAccountManager accountManager,SignInManager<User>signInManager)
        {
            _accountManager = accountManager;
            _signInManager = signInManager;
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
        [ValidateAntiForgeryToken]
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
                // Redirect to the Login action upon successful registration
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

        [HttpPost]
        [Route("Account/Login")]
        [ValidateAntiForgeryToken]
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

            return View(loginDto);
        }


        // POST: Account/Logout
        [HttpPost]
        [Route("Account/Logout")]
        public async Task<IActionResult> LogoutUser()
        {
            await _signInManager.SignOutAsync();
            HttpContext.Session.Clear(); 
            return RedirectToAction("Login", "Account");
        }

    }
}

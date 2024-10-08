using InventoryManagementSystem.BLL.Dto.RegisterUser;
using InventoryManagementSystem.DAL.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public object userManager { get; private set; }

        [HttpGet]
        public IActionResult Register()
        {
            return Ok();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUser newUser)
        {
            if (ModelState.IsValid)
            {
                //create account
                ApplicationUser userModel = new ApplicationUser();
                userModel.UserName = newUser.UserName;
                userModel.PasswordHash = newUser.Password;
                userModel.Address = newUser.Address;
                IdentityResult result = await _userManager.CreateAsync(userModel, newUser.Password);
                if (result.Succeeded == true)
                {
                    //creat cookie
                    //await for make Async 
                    //Signinmanger for making cookies and send user to fill info
                    // false to don`t make it session
                    await _signInManager.SignInAsync(userModel, false);
                    return RedirectToAction("Index", "Student");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
            return Ok(newUser);
        }
    }
}

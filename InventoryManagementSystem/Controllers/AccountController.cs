using InventoryManagementSystem.BLL.Dto.Login;
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

        [HttpGet("Login")]
        public IActionResult Login()
        {
            return Ok();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUser user)
        {
            //Check
            if (ModelState.IsValid)
            {
                //Search for object Found
                ApplicationUser userModel = await _userManager.FindByNameAsync(user.UserName);
                if (userModel != null)
                {
                    //compare input val 
                    bool found = await _userManager.CheckPasswordAsync(userModel, user.PassWord);
                    if (found)
                    {
                        // now to crate cookie
                        await _signInManager.SignInAsync(userModel, user.RememberMe);//check from prop
                        return Ok();
                    }
                }
                ModelState.AddModelError("", "UserName And password not valid");
            }
            return NotFound();

        }
        [HttpGet("Register")]
        public IActionResult Register()
        {
            var users = _userManager.Users.ToList(); //  Get all users
            return Ok(); 
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUser newUser)
        {
            if (ModelState.IsValid)
            {
                //create account
                ApplicationUser userModel = new ApplicationUser();
                userModel.UserName = newUser.UserName;
                userModel.PasswordHash = newUser.Password;
                userModel.Address = newUser.Address;
                IdentityResult result = await _userManager.CreateAsync(userModel, newUser.Password);//for check password
                if (result.Succeeded == true)
                {
                    //creat cookie
                    //await for make Async 
                    //Signinmanger for making cookies and send user to fill info
                    // false to don`t make it session
                    await _signInManager.SignInAsync(userModel, false);
                    return Ok();

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
        
        //[HttpPost]
        //public async Task<IActionResult> Logout()
        //{
        //    await _signInManager.SignOutAsync();
        //    return Ok();
        //}
    }
}

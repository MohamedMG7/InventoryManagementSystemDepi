using InventoryManagementSystem.BLL.Dto.UserDtos;
using InventoryManagementSystem.DAL.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InventoryManagementSystem.BLL.Manager.AccountManager
{
    public class AccountManager : IAccountManager
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
		private readonly IConfiguration _configuration;

		public AccountManager(UserManager<User> userManager,SignInManager<User> signInManager, RoleManager<IdentityRole<int>> roleManager, IConfiguration configuration)  
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        //public async Task<string> LoginUser(UserLoginDto loginDto) // we will return a string (Token) To The User
        //{
        //    var userModel = await _userManager.FindByNameAsync(loginDto.Email);
        //    var userRoles = await _userManager.GetRolesAsync(userModel);
        //    string userRole = userRoles.FirstOrDefault();

        //    if (userModel != null)
        //    {
        //        bool isPasswordValid = await _userManager.CheckPasswordAsync(userModel, loginDto.Password);
        //        if (isPasswordValid)
        //        {
        //            List<Claim> claims = new List<Claim>()
        //            {
        //                new Claim(JwtRegisteredClaimNames.Sub, userModel.Id.ToString()),
        //                new Claim(JwtRegisteredClaimNames.Email, userModel.Email),
        //                new Claim(ClaimTypes.Name, userModel.Name),
        //                new Claim(ClaimTypes.Role, userRole),
        //            };
        //            return GenerateToken(claims, true);
        //        }
        //    }

        //    return "Invalid Email Or Password";
        //}


        //public async Task<IdentityResult> RegisterUser(UserRegisterDto registerDto)
        //{
        //    var user = new User
        //    {
        //        UserName = registerDto.Email,
        //        Email = registerDto.Email,
        //        Name = registerDto.Name,
        //        PhoneNumber = registerDto.PhoneNumber,
        //        State = registerDto.State,
        //        City = registerDto.City,
        //        Street = registerDto.Street,
        //        UserType = registerDto.UserType
        //    };


        //    // Create the user with the password
        //    var result = await _userManager.CreateAsync(user, registerDto.Password);

        //    if (result.Succeeded)
        //    {
        //        // Assign Role
        //        if (await _roleManager.RoleExistsAsync(registerDto.UserType))
        //        {
        //            await _userManager.AddToRoleAsync(user, registerDto.UserType);
        //        }
        //        else
        //        {
        //            // Handle the case where the role doesn't exist
        //            return IdentityResult.Failed(new IdentityError
        //            {
        //                Description = $"Role '{registerDto.UserType}' does not exist."
        //            });
        //        }
        //    }
        //    return result; // Return the IdentityResult
        //}

        //public async Task LogoutUser()
        //{
        //    await _signInManager.SignOutAsync();
        //}

        ////creating JWT
        //private string GenerateToken(IList<Claim> claims, bool RememberMe)
        //{
        //    var SecretKeyString = _configuration["Jwt:Key"];
        //    var issuer = _configuration["Jwt:Issuer"];
        //    var audience = _configuration["Jwt:Audience"];
        //    var SecretKeyByte = Encoding.ASCII.GetBytes(SecretKeyString);
        //    SecurityKey securityKey = new SymmetricSecurityKey(SecretKeyByte);

        //    //Combind SecretKey , HasingAlgorithm (SigningCredentials)
        //    SigningCredentials signingCredential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        //    DateTime tokenExpiration = RememberMe ? DateTime.Now.AddDays(30) : DateTime.Now.AddHours(2);
        //    JwtSecurityToken jwtSecurityToken = new JwtSecurityToken
        //    (
        //        claims: claims,
        //        issuer: issuer,
        //        audience: audience,
        //        signingCredentials: signingCredential,
        //        expires: tokenExpiration
        //    );

        //    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
        //    string token = handler.WriteToken(jwtSecurityToken);
        //    return token;
        //}

        public async Task<string> LoginUser(UserLoginDto loginDto, bool rememberMe)
        {
            var userModel = await _userManager.FindByNameAsync(loginDto.Email);
            if (userModel != null)
            {
                // Check if the provided password is valid
                var result = await _signInManager.PasswordSignInAsync(userModel.UserName, loginDto.Password, rememberMe == false, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    // Successful login
                    return "Login successful";
                }
            }

            return "Invalid Email or Password";
        }

        public async Task<IdentityResult> RegisterUser(UserRegisterDto registerDto)
        {
            var user = new User
            {
                UserName = registerDto.Email,
                Email = registerDto.Email,
                Name = registerDto.Name,
                PhoneNumber = registerDto.PhoneNumber,
                State = registerDto.State,
                City = registerDto.City,
                Street = registerDto.Street,
                UserType = registerDto.UserType
            };

            // Create the user with the provided password
            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                // Assign the role
                if (await _roleManager.RoleExistsAsync(registerDto.UserType))
                {
                    await _userManager.AddToRoleAsync(user, registerDto.UserType);
                }
                else
                {
                    return IdentityResult.Failed(new IdentityError { Description = $"Role '{registerDto.UserType}' does not exist." });
                }
            }
            return result;
        }

        public async Task LogoutUser()
        {
            await _signInManager.SignOutAsync();
        }

    }
}

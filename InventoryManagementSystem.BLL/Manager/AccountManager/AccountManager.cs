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

        public async Task<string> LoginUser(UserLoginDto loginDto) // we will return a string (Token) To The User
        {
            var userModel = await _userManager.FindByNameAsync(loginDto.Email);
			if (userModel != null)
			{
				bool isPasswordValid = await _userManager.CheckPasswordAsync(userModel, loginDto.Password);
				if (isPasswordValid)
				{
					// Generate JWT token
					var tokenHandler = new JwtSecurityTokenHandler();
					var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
					var tokenDescriptor = new SecurityTokenDescriptor
					{
						Subject = new ClaimsIdentity(new[]
						{
					new Claim(ClaimTypes.NameIdentifier, userModel.Id.ToString()),
					new Claim(ClaimTypes.Email, userModel.Email)
					}),
						Expires = DateTime.UtcNow.AddHours(1),
						SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
					};

					var token = tokenHandler.CreateToken(tokenDescriptor);
					return tokenHandler.WriteToken(token); // Return the token to the client
				}
			}

			return "Invalid Email Or Password"; 
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


            // Create the user with the password
            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded) {
				// Assign Role
				if (await _roleManager.RoleExistsAsync(registerDto.UserType)) 
				{
					await _userManager.AddToRoleAsync(user, registerDto.UserType);
				}
				else
				{
					// Handle the case where the role doesn't exist
					return IdentityResult.Failed(new IdentityError
					{
						Description = $"Role '{registerDto.UserType}' does not exist."
					});
				}
			}
            return result; // Return the IdentityResult
        }

        public async Task LogoutUser()
        {
            await _signInManager.SignOutAsync();
        }

    }
}

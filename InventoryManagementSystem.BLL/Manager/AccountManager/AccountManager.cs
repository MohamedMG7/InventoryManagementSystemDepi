using InventoryManagementSystem.BLL.Dto.UserDtos;
using InventoryManagementSystem.DAL.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace InventoryManagementSystem.BLL.Manager.AccountManager
{
	public class AccountManager : IAccountManager
	{
		private readonly UserManager<User> _userManager;
		

		public AccountManager(UserManager<User> userManager)
		{
			_userManager = userManager;
			
		}

		public async Task<IdentityResult> RegisterUser(UserRegisterDto registerDto)
		{
			var user = new User
			{
				UserName = registerDto.Email,  // Set UserName to Email for Identity
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
			return result; // Return the IdentityResult
		}

		//public async Task<SignInResult> LoginUser(UserLoginDto loginDto)
		//{
		//	// Attempt to sign in the user with their email and password
		//	return await _signInManager.PasswordSignInAsync(
		//		loginDto.Email,
		//		loginDto.Password,
		//		loginDto.RememberMe,
		//		lockoutOnFailure: false);
		//}

		//public async Task LogoutUser()
		//{
		//	// Sign out the user
		//	await _signInManager.SignOutAsync();
		//}
	}
}

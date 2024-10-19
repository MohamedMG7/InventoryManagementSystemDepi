﻿using InventoryManagementSystem.BLL.Dto.UserDtos;
using InventoryManagementSystem.DAL.Data.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace InventoryManagementSystem.BLL.Manager.AccountManager
{
    public class AccountManager : IAccountManager
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountManager(UserManager<User> userManager
            ,SignInManager<User> signInManager)  
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<SignInResult> LoginUser(UserLoginDto loginDto)
        {
            if (loginDto == null)
            {
                return SignInResult.Failed;
            }

            var userModel = await _userManager.FindByNameAsync(loginDto.Email);
            if (userModel != null)
            {
                bool isPasswordValid = await _userManager.CheckPasswordAsync(userModel, loginDto.Password);
                if (isPasswordValid)
                {
                    await _signInManager.SignInAsync(userModel, loginDto.RememberMe);
                    return SignInResult.Success;
                }
            }
            return SignInResult.Failed;
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
            await _signInManager.SignInAsync(user, false);
            return result; // Return the IdentityResult
        }

        public async Task LogoutUser()
        {
            await _signInManager.SignOutAsync();
        }

    }
}

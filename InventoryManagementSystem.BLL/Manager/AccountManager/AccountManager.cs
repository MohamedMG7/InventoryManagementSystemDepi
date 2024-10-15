﻿using InventoryManagementSystem.BLL.Dto;
using InventoryManagementSystem.BLL.Dto.UserDtos;
using InventoryManagementSystem.DAL.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace InventoryManagementSystem.BLL.Manager.AccountManager
{
    public class AccountManager : IAccountManager
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public AccountManager(UserManager<User> userManager
            ,SignInManager<User> signInManager,
            RoleManager<IdentityRole<int>> roleManager
            )  // Corrected constructor
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<SignInResult> LoginUser(Dto.UserDtos.UserLoginDto loginDto)
        {
            var userModel = await _userManager.FindByNameAsync(loginDto.Email);
            if (userModel != null)
            {
                bool isPasswordValid = await _userManager.CheckPasswordAsync(userModel, loginDto.Password);
                if (isPasswordValid)
                {
                    await _signInManager.SignInAsync(userModel, loginDto.RememberMe);
                    return SignInResult.Success; // or return a custom result
                }
            }

            return SignInResult.Failed; // or handle invalid login attempts differently
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

        public async Task LogoutUser()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> CreateRoleAsync(RoleMnagerDto newRole)
        {
            IdentityRole<int> role = new IdentityRole<int>
            {
                Name = newRole.RoleName
            };
            IdentityResult result = await _roleManager.CreateAsync(role);
            return result;
        }

        public Task<IdentityResult> AddRoleAsync(UserRegisterDto registerDto, string roleName)
        {
            throw new NotImplementedException();
        }

        //public async Task<IdentityResult> AddRoleAsync(UserRegisterDto registerDto, string roleName)
        //{
        //    var user = await _userManager.FindByEmailAsync(registerDto.Email);
        //    if (user != null)
        //    {
        //        if (!await _roleManager.RoleExistsAsync(roleName))
        //        {
        //            await _roleManager.CreateAsync(new IdentityRole(roleName));
        //        }

        //        return await _userManager.AddToRoleAsync(user, roleName);
        //    }
        //    return IdentityResult.Failed(new IdentityError { Description = "User not found." });
        //}

    }
}

using InventoryManagementSystem.BLL.Dto;
using InventoryManagementSystem.BLL.Dto.UserDtos;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using IdentityResult = Microsoft.AspNetCore.Identity.IdentityResult;
namespace InventoryManagementSystem.BLL.Manager.AccountManager
{
	public interface IAccountManager
	{
		Task<IdentityResult> RegisterUser(UserRegisterDto registerDto);
		Task<SignInResult> LoginUser(Dto.UserDtos.UserLoginDto loginDto);
        Task<IdentityResult> CreateRoleAsync(RoleMnagerDto newRole);
        Task LogoutUser();
        Task<IdentityResult> AddRoleAsync(UserRegisterDto registerDto, string roleName); 

    }
}

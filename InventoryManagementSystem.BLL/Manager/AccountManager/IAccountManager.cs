using InventoryManagementSystem.BLL.Dto.UserDtos;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Identity;
namespace InventoryManagementSystem.BLL.Manager.AccountManager
{
	public interface IAccountManager
	{
		Task<IdentityResult> RegisterUser(UserRegisterDto registerDto);
		Task<SignInResult> LoginUser(UserLoginDto loginDto);
		Task LogoutUser();
	}
}


namespace InventoryManagementSystem.BLL.Dto.UserDtos
{
	public class UserLoginDto
	{
		public string Email { get; set; } // User's email
		public string Password { get; set; } // User's password
		public bool RememberMe { get; set; } // Option to remember user on device
	}
}

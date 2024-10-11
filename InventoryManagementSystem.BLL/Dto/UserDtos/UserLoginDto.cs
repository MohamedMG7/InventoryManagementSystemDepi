
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.BLL.Dto.UserDtos
{
	public class UserLoginDto
	{
		[Required]
		public string Email { get; set; } // User's email
        [Required]
		[DataType(DataType.Password)]
        public string Password { get; set; } // User's password

		public bool RememberMe { get; set; } // Option to remember user on device
	}
}

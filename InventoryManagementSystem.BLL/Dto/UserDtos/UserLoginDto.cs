
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.BLL.Dto.UserDtos
{
	public class UserLoginDto
	{
		[Required(ErrorMessage = "Email Is Required")]
		[EmailAddress(ErrorMessage = "Invalid Email Format")]
		public string Email { get; set; } 
        
		[Required(ErrorMessage = "Password Is Required")]
        public string Password { get; set; } 
	}
}

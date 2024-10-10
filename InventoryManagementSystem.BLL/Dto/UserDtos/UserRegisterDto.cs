
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.BLL.Dto.UserDtos
{
	public class UserRegisterDto
	{
		[Required]
		public string Name { get; set; } // User's full name

		[Required]
		[EmailAddress]
		public string Email { get; set; } // Email for login

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; } // Password for account

		[Required]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; } // Confirm password

		
		public string State { get; set; } 
		public string City { get; set; }  
		public string Street { get; set; } 
		public string PhoneNumber { get; set; }

		// You can add more fields depending on what you need during registration
		public string UserType { get; set; } // E.g., 'Admin' or 'Customer' depending on which do i enter
	}
}

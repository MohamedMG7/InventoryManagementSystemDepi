using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.BLL.Dto.UserDtos
{
	public class UserRegisterDto
	{
		[Required]
		public string Name { get; set; } 

		[Required]
		[EmailAddress]
		public string Email { get; set; } 

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; } 

		[Required]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; }

		
		public string State { get; set; } 
		public string City { get; set; }  
		public string Street { get; set; } 
		public string PhoneNumber { get; set; }

		public string UserType { get; set; } 
	}
}

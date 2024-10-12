using Microsoft.AspNetCore.Identity;

namespace InventoryManagementSystem.DAL.Data.Models
{
	public class User : IdentityUser<int> // generates int pk
	{
		// Remove Email, PasswordHash, PhoneNumber since they are included in IdentityUser.
		public string Name { get; set; }  
		public string State { get; set; }
		public string City { get; set; }
		public string Street { get; set; }
		public string UserType { get; set; }  
        public bool isDeleted { get; set; }

        public ShoppingCart shoppingCart { get; set; }
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();	
    }
}

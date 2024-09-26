using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.DAL.Data.Models
{
	public class User
	{
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PhoneNumber { get; set; }
        public string UserType { get; set; }

        
        public ShoppingCart shoppingCart { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}

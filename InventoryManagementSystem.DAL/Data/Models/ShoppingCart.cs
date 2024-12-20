﻿
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagementSystem.DAL.Data.Models
{
	public class ShoppingCart
	{
        public int ShoppingCartId { get; set; }
        public double TotalPrice { get; set; } // should be autocalculated
		[ForeignKey("user")]
		public int UserId { get; set; }
        public User user { get; set; }
		public ICollection<CartProduct> CartProducts { get; set; } = new HashSet<CartProduct>();
        public bool isDeleted { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.DAL.Data.Models
{
	public class Product
	{
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }

        
        public int CompanyId { get; set; }
        public Company company { get; set; }

        public int CategoryId { get; set; }
        public Category category { get; set; }

        public ICollection<CartProduct> CartProducts { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}

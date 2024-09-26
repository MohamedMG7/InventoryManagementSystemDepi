using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.DAL.Data.Models
{
	public class OrderProduct
	{
        public int OrderId { get; set; }
        public Order order { get; set; }

        public int ProductId { get; set; }
        public Product product { get; set; }

        public int Quantity { get; set; }
        public double PriceAtPurchase { get; set; }

    }
}

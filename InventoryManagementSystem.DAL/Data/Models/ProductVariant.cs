using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.DAL.Data.Models
{
	public class ProductVariant
	{
        public int ProductVariantId { get; set; }
        public int ProductId { get; set; }
        public Product product { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public int QuantityInStock { get; set; }
        public decimal Weight { get; set; }
        public string? Dimensions { get; set; }

		public ICollection<PurchaseProduct> purchaseProducts { get; set; }

	}
}

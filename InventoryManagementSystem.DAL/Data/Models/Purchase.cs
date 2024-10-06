
namespace InventoryManagementSystem.DAL.Data.Models
{
	public class Purchase
	{
        public int PurchaseId { get; set; }
        public DateTime DateTime { get; set; }
        public double TotalCost { get; set; }
        public string Notes { get; set; }
        public string PaymentMethod { get; set; }
        public ICollection<PurchaseProduct> purchaseProducts { get; set; }

        public Purchase() { 
            DateTime = DateTime.Now;
        }
    }
}

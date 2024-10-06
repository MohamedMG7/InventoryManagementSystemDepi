
namespace InventoryManagementSystem.BLL.Dto.PurchaseDtos
{
	public class PurchaseReadDto
	{
		public int PurchaseId { get; set; }
		public DateTime DateTime { get; set; }
		public double TotalCost { get; set; }
		public string Notes { get; set; }
		public string PaymentMethod { get; set; }
	}
}


using InventoryManagementSystem.BLL.Dto.PurchaseProductDtos;


namespace InventoryManagementSystem.BLL.Dto.PurchaseDtos
{
	public class PurchaseAddDto
	{
		public string Notes { get; set; }
		public string PaymentMethod { get; set; }
        public ICollection<PurchaseProductAddDto> Products { get; set; }
    }
}

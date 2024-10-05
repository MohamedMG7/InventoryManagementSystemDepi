
using InventoryManagementSystem.DAL.Data.Models;

namespace InventoryManagementSystem.BLL.Dto.PaymentDtos
{
    public class PaymentAddDto
    {
        public string PaymentType { get; set; }
        public string PaymentStatus { get; set; }
        public int OrderId { get; set; }

    }
}

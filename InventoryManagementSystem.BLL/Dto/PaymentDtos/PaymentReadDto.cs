

namespace InventoryManagementSystem.BLL.Dto.PaymentDtos
{
    public class PaymentReadDto
    {
        public int PaymentId { get; set; }
        public string PaymentType { get; set; }
        public string PaymentStatus { get; set; }
        public TimeOnly PaymentTime { get; set; }
        public int OrderId { get; set; }
    }
}

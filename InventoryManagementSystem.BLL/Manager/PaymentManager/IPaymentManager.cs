
using InventoryManagementSystem.BLL.Dto.PaymentDtos;

namespace InventoryManagementSystem.BLL.Manager.PaymentManager
{
    public interface IPaymentManager
    {
        IEnumerable<PaymentReadDto> GetAll();
        PaymentReadDto GetbyId(int id);
        void Add(PaymentAddDto PaymentAddDto);
        void Delete(int id);
        void SaveChanges();
    }
}

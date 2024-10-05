
using InventoryManagementSystem.BLL.Dto.PaymentDtos;
using InventoryManagementSystem.BLL.Dto.ShoopinhCartDto;
using InventoryManagementSystem.DAL.Data.Models;
using InventoryManagementSystem.DAL.Reposatiries;
namespace InventoryManagementSystem.BLL.Manager.PaymentManager
{
    public class PaymentManager : IPaymentManager
    {
        private readonly IPaymentRepo _paymentRepo;

        public PaymentManager(IPaymentRepo paymentRepo)
        {
            _paymentRepo = paymentRepo;
        }
        public void Add(PaymentAddDto PaymentAddDto)
        {
            var paymenModel = new Payment{ 
                PaymentType = PaymentAddDto.PaymentType,
                PaymentStatus = PaymentAddDto.PaymentStatus,
                
                OrderId = PaymentAddDto.OrderId

            };

            paymenModel.PaymentTime = TimeOnly.FromDateTime(DateTime.Now);

            _paymentRepo.Add(paymenModel);
            _paymentRepo.SaveChanges();

        }

        public void Delete(int id)
        {
            var paymentModel = _paymentRepo.GetbyID(id);
            _paymentRepo.Delete(paymentModel);
            _paymentRepo.SaveChanges();
        }

        public IEnumerable<PaymentReadDto> GetAll()
        {
            var Payments = _paymentRepo.GetAll();
            var PaymentsList = Payments.Select(x => new PaymentReadDto
            {
                PaymentId = x.PaymentId,
                PaymentType = x.PaymentType,
                PaymentStatus = x.PaymentStatus,
                PaymentTime = x.PaymentTime,
                OrderId = x.OrderId
            });
            return PaymentsList;
        }

        public PaymentReadDto GetbyId(int id)
        {
            var paymentModel = _paymentRepo.GetbyID(id);
            PaymentReadDto paymentReadDto = new PaymentReadDto
            {
                PaymentId = paymentModel.PaymentId,
                PaymentType = paymentModel.PaymentType,
                PaymentStatus = paymentModel.PaymentStatus,
                PaymentTime = paymentModel.PaymentTime,
                OrderId = paymentModel.OrderId
            };

            return paymentReadDto;
        }

        public void SaveChanges()
        {
            _paymentRepo.SaveChanges();
        }
    }
}

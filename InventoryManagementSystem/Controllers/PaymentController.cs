using InventoryManagementSystem.BLL.Dto.PaymentDtos;
using InventoryManagementSystem.BLL.Manager.PaymentManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentManager _paymentManager;
        public PaymentController(IPaymentManager paymentManager)
        {
            _paymentManager = paymentManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PaymentReadDto>> GetAll()
        {
            return Ok(_paymentManager.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(_paymentManager.GetbyId(id));
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteById(int id)
        {
            _paymentManager.Delete(id);
            return NoContent();
        }

        [HttpPost]
        public ActionResult Add(PaymentAddDto paymentAddDto)
        {
            _paymentManager.Add(paymentAddDto);
            return Ok(paymentAddDto);

        }
    }
}

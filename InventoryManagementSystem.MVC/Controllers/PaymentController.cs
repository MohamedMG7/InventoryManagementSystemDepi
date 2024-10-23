using InventoryManagementSystem.BLL.Dto.PaymentDtos;
using InventoryManagementSystem.BLL.Manager.PaymentManager;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InventoryManagementSystem.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentManager _paymentManager;

        public PaymentController(IPaymentManager paymentManager)
        {
            _paymentManager = paymentManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var payments = _paymentManager.GetAll();
            return View(payments);
        }

        [HttpGet]
        [Route("Details/{id}")]
        public IActionResult Details(int id)
        {
            var payment = _paymentManager.GetbyId(id);
            if (payment == null)
            {
                return NotFound();
            }
            return View(payment);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PaymentAddDto paymentAddDto)
        {
            if (ModelState.IsValid)
            {
                _paymentManager.Add(paymentAddDto);
                return RedirectToAction("Index");
            }
            return View(paymentAddDto);
        }

        [HttpPost]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _paymentManager.Delete(id);
            return RedirectToAction("Index");
        }
    }
}

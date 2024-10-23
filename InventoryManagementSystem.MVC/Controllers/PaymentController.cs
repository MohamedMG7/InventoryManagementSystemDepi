using InventoryManagementSystem.BLL.Dto.PaymentDtos;
using InventoryManagementSystem.BLL.Manager.PaymentManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace InventoryManagementSystem.Controllers
{
    [Route("payment")]
    public class PaymentController : Controller
    {
        private readonly IPaymentManager _paymentManager;

        public PaymentController(IPaymentManager paymentManager)
        {
            _paymentManager = paymentManager;
        }

        [HttpGet]
        [Route("")]
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
        [Route("Create")]

        public IActionResult Create()
        {
           
            ViewBag.PaymentTypes = new List<SelectListItem>
    {
        new SelectListItem { Text = "Visa", Value = "Visa" },
        new SelectListItem { Text = "Cash", Value = "Cash" }
    };

            return View();
        }



        [HttpPost]
        [Route("Create")]
        public IActionResult Create(PaymentAddDto paymentAddDto)
        {
           // adding orderid
           // paymentAddDto.OrderId = 1;
            if (ModelState.IsValid)
            {
                _paymentManager.Add(paymentAddDto);
                return RedirectToAction("PaymentSucces");
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
        [HttpGet]
        [Route("PaymentSuccess")]
        public IActionResult PaymentSuccess()
        {
            return View();
        }

    }
}

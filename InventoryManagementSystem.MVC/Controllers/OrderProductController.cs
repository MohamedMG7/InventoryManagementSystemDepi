using InventoryManagementSystem.BLL.Dto.OrderProductDtos;
using InventoryManagementSystem.BLL.Manager.OrderProductManager;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InventoryManagementSystem.Controllers
{
    public class OrderProductController : Controller
    {
        private readonly IOrderProductManager _orderProductManager;

        public OrderProductController(IOrderProductManager orderProductManager)
        {
            _orderProductManager = orderProductManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var orderProducts = _orderProductManager.GetAll();
            return View(orderProducts);
        }

        [HttpGet]
        [Route("Details/{OrderId}/{ProductId}")]
        public IActionResult Details(int OrderId, int ProductId)
        {
            var orderProduct = _orderProductManager.GetbyId(OrderId, ProductId);
            if (orderProduct == null)
            {
                return NotFound();
            }
            return View(orderProduct);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(OrderProductAddDto orderProductAddDto)
        {
            if (ModelState.IsValid)
            {
                _orderProductManager.Add(orderProductAddDto);
                return RedirectToAction("Index");
            }
            return View(orderProductAddDto);
        }

        [HttpPost]
        [Route("Delete/{OrderId}/{ProductId}")]
        public IActionResult Delete(int OrderId, int ProductId)
        {
            _orderProductManager.Delete(OrderId, ProductId);
            return RedirectToAction("Index");
        }
    }
}

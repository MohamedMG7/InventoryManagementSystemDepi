using InventoryManagementSystem.BLL.Dto.OrderDtos;
using InventoryManagementSystem.BLL.Manager.OrderManager;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InventoryManagementSystem.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderManager _orderManager;

        public OrderController(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var orders = _orderManager.GetAll();
            return View(orders); 
        }


        [HttpGet]
        [Route("Details/{id}")]
        public IActionResult Details(int id)
        {
            var order = _orderManager.GetbyId(id);
            if (order == null)
            {
                return NotFound(); 
            }
            return View(order); 
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(); 
        }


        [HttpPost]
        public IActionResult Create(OrderAddDto orderAddDto)
        {
            if (ModelState.IsValid) 
            {
                _orderManager.Add(orderAddDto);
                return RedirectToAction("Index"); 
            }
            return View(orderAddDto); 
        }


        [HttpPost]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _orderManager.Delete(id);
            return RedirectToAction("Index"); 
        }
        // [HttpGet("with-products/{orderId}")]
        // public ActionResult<ReadOrderWithProductsDto> GetOrderWithProductsData(int orderId)
        // {
        //     var orderWithProducts = _orderManager.GetOrderWithProductsData(orderId);
        //     return Ok(orderWithProducts);
        // }
    }
}

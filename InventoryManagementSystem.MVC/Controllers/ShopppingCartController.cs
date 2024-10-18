using Microsoft.AspNetCore.Mvc;
using InventoryManagementSystem.BLL.Manager.ShoppingCartManager;
using InventoryManagementSystem.BLL.Dto.ShoopinhCartDto;
using System.Collections.Generic;

namespace InventoryManagementSystem.Controllers
{
    [Route("[controller]")]
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartManger _shoppingCartManager;

        public ShoppingCartController(IShoppingCartManger shoppingCartManager)
        {
            _shoppingCartManager = shoppingCartManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var shoppingCarts = _shoppingCartManager.GetAll();
            return View(shoppingCarts);
        }

        [HttpGet]
        [Route("Details/{id}")]
        public IActionResult Details(int id)
        {
            var shoppingCart = _shoppingCartManager.GetbyId(id);
            if (shoppingCart == null)
            {
                return NotFound();
            }
            return View(shoppingCart);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ShoppingCartAddDto shoppingCartAddDto)
        {
            if (ModelState.IsValid)
            {
                _shoppingCartManager.Add(shoppingCartAddDto);
                return RedirectToAction("Index");
            }
            return View(shoppingCartAddDto);
        }

        [HttpPost]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _shoppingCartManager.Delete(id);
            return RedirectToAction("Index");
        }
    }
}

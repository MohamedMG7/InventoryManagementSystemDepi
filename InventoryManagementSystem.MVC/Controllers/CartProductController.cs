using InventoryManagementSystem.BLL.Dto.CartProductDtos;
using InventoryManagementSystem.BLL.Manager.CartProductManager;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InventoryManagementSystem.Controllers
{
    public class CartProductController : Controller
    {
        private readonly ICartProductManager _cartProductManager;

        public CartProductController(ICartProductManager cartProductManager)
        {
            _cartProductManager = cartProductManager;
        }

        [HttpGet]
        public IActionResult Index() // get all
        {
            var cartProducts = _cartProductManager.GetAll();
            return View(cartProducts);
        }

        [HttpGet]
        [Route("{orderId}/{productId}")]
        public IActionResult Details(int orderId, int productId) // get by id
        {
            var cartProduct = _cartProductManager.GetbyId(orderId, productId);
            if (cartProduct == null)
            {
                return NotFound(); // Handle not found
            }
            return View(cartProduct);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(CartProductAddDto cartProductAddDto)
        {
            if (ModelState.IsValid)
            {
                _cartProductManager.Add(cartProductAddDto);
                return RedirectToAction(nameof(Index));
            }
            return View(cartProductAddDto);
        }

        [HttpGet]
        [Route("{shoppingCartId}/{productId}/Edit")]
        public IActionResult Edit(int shoppingCartId, int productId)
        {
            var cartProduct = _cartProductManager.GetbyId(shoppingCartId, productId);
            if (cartProduct == null)
            {
                return NotFound(); // Handle not found
            }
            return View(cartProduct);
        }

        [HttpPost]
        [Route("{shoppingCartId}/{productId}/Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CartProductUpdateDto cartProductUpdateDto)
        {
            if (ModelState.IsValid)
            {
                _cartProductManager.Update(cartProductUpdateDto);
                return RedirectToAction(nameof(Index));
            }
            return View(cartProductUpdateDto);
        }

        [HttpPost]
        [Route("{orderId}/{productId}/Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int orderId, int productId)
        {
            _cartProductManager.Delete(orderId, productId);
            return RedirectToAction(nameof(Index));
        }
    }
}

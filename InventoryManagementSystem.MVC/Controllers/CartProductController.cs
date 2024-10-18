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
        public IActionResult Index()  //get all;
        {
            var cartProducts = _cartProductManager.GetAll();
            return View(cartProducts); 
        }

        [HttpGet]
        [Route("{OrderId}/{ProductId}")]
        public IActionResult Details(int OrderId, int ProductId) //get by id
        {
            var cartProduct = _cartProductManager.GetbyId(OrderId, ProductId);
            if (cartProduct == null)
            {
                return NotFound(); 
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
        [Route("{shoppingCartId}/{ProductId}/Edit")]
        public IActionResult Edit(int shoppingCartId, int ProductId)
        {
            var cartProduct = _cartProductManager.GetbyId(shoppingCartId, ProductId);
            if (cartProduct == null)
            {
                return NotFound(); 
            }
            return View(cartProduct);
        }

        [HttpPost]
        [Route("{shoppingCartId}/{ProductId}/Edit")]
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
        [Route("{OrderId}/{ProductId}/Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int OrderId, int ProductId)
        {
            _cartProductManager.Delete(OrderId, ProductId);
            return RedirectToAction(nameof(Index)); 
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using InventoryManagementSystem.BLL.Manager;
using InventoryManagementSystem.BLL.Dto;
using System.Collections.Generic;

namespace InventoryManagementSystem.Controllers
{
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;

        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products = _productManager.GetAll();
            return View(products);
        }




        [HttpGet]
        [Route("Category/{categoryId}/Products")]
        public IActionResult ProductsByCategory(int categoryId)
        {
            var products = _productManager.GetProductsByCategory(categoryId);
            return View(products);
        }


        [HttpGet]
        [Route("Details/{id}")]
        public IActionResult Details(int id)
        {
            var product = _productManager.GetbyId(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductAddDto productAddDto)
        {
            if (ModelState.IsValid)
            {
                _productManager.Add(productAddDto);
                return RedirectToAction("Index");
            }
            return View(productAddDto);
        }

        [HttpPost]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _productManager.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, ProductUpdateDto productUpdateDto)
        {
            if (id != productUpdateDto.Id)
            {
                return BadRequest();
            }
            _productManager.Update(productUpdateDto);
            return Ok();
        }
    }
}

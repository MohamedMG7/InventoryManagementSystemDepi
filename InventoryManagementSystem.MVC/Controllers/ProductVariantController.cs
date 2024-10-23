using Microsoft.AspNetCore.Mvc;
using InventoryManagementSystem.BLL.Manager.ProductVariantManager;
using InventoryManagementSystem.BLL.Dto.ProductVariantDtos;
using System.Collections.Generic;

namespace InventoryManagementSystem.Controllers
{
    [Route("[controller]")]
    public class ProductVariantController : Controller
    {
        private readonly IProductVariantManager _productVariantManager;

        public ProductVariantController(IProductVariantManager productVariantManager)
        {
            _productVariantManager = productVariantManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var productVariants = _productVariantManager.GetAll();
            return View(productVariants);
        }

        [HttpGet]
        [Route("Details/{id}")]
        public IActionResult Details(int id)
        {
            var productVariant = _productVariantManager.GetbyId(id);
            if (productVariant == null)
            {
                return NotFound();
            }
            return View(productVariant);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductVariantAddDto productAddDto)
        {
            if (ModelState.IsValid)
            {
                _productVariantManager.Add(productAddDto);
                return RedirectToAction("Index");
            }
            return View(productAddDto);
        }

        [HttpPost]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _productVariantManager.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, ProductVariantUpdateDto productVariantUpdateDto)
        {
            if (id != productVariantUpdateDto.ProductVariantId)
            {
                return BadRequest();
            }
            _productVariantManager.Update(productVariantUpdateDto);
            return Ok();
        }
    }
}

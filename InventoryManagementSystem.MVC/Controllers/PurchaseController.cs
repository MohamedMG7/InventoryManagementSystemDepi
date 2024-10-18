using Microsoft.AspNetCore.Mvc;
using InventoryManagementSystem.BLL.Manager.PurchaseManager;
using InventoryManagementSystem.BLL.Dto.PurchaseDtos;
using System.Collections.Generic;

namespace InventoryManagementSystem.Controllers
{
    [Route("[controller]")]
    public class PurchaseController : Controller
    {
        private readonly IPurchaseManager _purchaseManager;

        public PurchaseController(IPurchaseManager purchaseManager)
        {
            _purchaseManager = purchaseManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var purchases = _purchaseManager.GetAll();
            return View(purchases);
        }

        [HttpGet]
        [Route("Details/{id}")]
        public IActionResult Details(int id)
        {
            var purchase = _purchaseManager.GetbyId(id);
            if (purchase == null)
            {
                return NotFound();
            }
            return View(purchase);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PurchaseAddDto purchaseAddDto)
        {
            if (ModelState.IsValid)
            {
                _purchaseManager.Add(purchaseAddDto);
                return RedirectToAction("Index");
            }
            return View(purchaseAddDto);
        }

        [HttpPost]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _purchaseManager.Delete(id);
            return RedirectToAction("Index");
        }
    }
}

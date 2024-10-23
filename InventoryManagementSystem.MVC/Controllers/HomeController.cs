using Microsoft.AspNetCore.Mvc;
using InventoryManagementSystem.BLL.Dto.CategoryDtos;
using InventoryManagementSystem.BLL.Manager;
using System.Threading.Tasks;
using InventoryManagementSystem.MVC.Models;
using System.Diagnostics;
using InventoryManagementSystem.BLL.Manager.CategoryManager;
using InventoryManagementSystem.BLL.Manager;

namespace InventoryManagementSystem.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryManager _categoryManager;

        public HomeController(ICategoryManager categorymanager, IProductManager productManager)
        {
            _categoryManager = categorymanager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var categories = _categoryManager.GetAll().ToList();
            return View(categories);
        }
    }
}


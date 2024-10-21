using Microsoft.AspNetCore.Mvc;
using InventoryManagementSystem.BLL.Manager;
using InventoryManagementSystem.BLL.Dto;
using InventoryManagementSystem.BLL.Manager.CategoryManager;
using InventoryManagementSystem.BLL.Manager.CompanyManager;

namespace InventoryManagementSystem.Controllers
{
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;
        private readonly ICategoryManager _categoryManager; // Inject category service
        private readonly ICompanyManager _companyManager; // Inject company service

        public ProductController(IProductManager productManager, ICategoryManager categoryManager, ICompanyManager companyManager)
        {
            _productManager = productManager;
            _categoryManager = categoryManager;
            _companyManager = companyManager;
        }

        // GET: /Product/Create
        [HttpGet("/Product/Create")]
        public IActionResult Create()
        {
            // Fetch categories and companies
            ViewBag.categories = _categoryManager.GetAll(); // Fetch all categories
            ViewBag.companies = _companyManager.GetAll(); // Fetch all companies

            return View();
        }

        // POST: /Product/Create
        [HttpPost("/Product/Create")]
        public IActionResult Create(ProductAddDto productAddDto)
        {
            if (ModelState.IsValid)
            {
                _productManager.Add(productAddDto);
                return RedirectToAction("Index", "Home");
            }
            return View(productAddDto);
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
        public IActionResult Index()
        {
            var products = _productManager.GetAll();
            return View(products);
        }



        [HttpGet]
        [Route("Category/{categoryId}/Products")]
        public IActionResult ProductsByCategory(int categoryId)
        {
            var products = _productManager.GetByCategory(categoryId);
            if (products == null || !products.Any())
            {
                return View(new List<ProductReadDto>()); // Return empty list if no products are found
            }
            return View(products.ToList()); // Convert to List before passing to the view
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

using InventoryManagementSystem.BLL.Dto.CompanyDtos;
using InventoryManagementSystem.BLL.Manager.CompanyManager;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InventoryManagementSystem.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyManager _companyManager;

        public CompanyController(ICompanyManager companyManager)
        {
            _companyManager = companyManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var companies = _companyManager.GetAll();
            return View(companies); 
        }

        [HttpGet]
        [Route("Details/{id}")]
        public IActionResult Details(int id)
        {
            var company = _companyManager.GetbyId(id);
            if (company == null)
            {
                return NotFound(); 
            }
            return View(company);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult Create(CompanyAddDto companyAddDto)
        {
            if (ModelState.IsValid)
            {
                _companyManager.Add(companyAddDto);
                return RedirectToAction("Index"); 
            }
            return View(companyAddDto); 
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var company = _companyManager.GetbyId(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company); 
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public IActionResult Edit(int id, CompanyUpdateDto companyUpdateDto)
        {
            if (id != companyUpdateDto.CompanyId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _companyManager.Update(companyUpdateDto);
                return RedirectToAction("Index"); 
            }
            return View(companyUpdateDto); 
        }

        [HttpPost]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _companyManager.Delete(id);
            return RedirectToAction("Index"); 
        }
    }
}

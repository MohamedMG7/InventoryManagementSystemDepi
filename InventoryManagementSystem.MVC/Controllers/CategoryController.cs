using InventoryManagementSystem.BLL.Dto.CategoryDtos;
using InventoryManagementSystem.BLL.Manager.CategoryManager;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InventoryManagementSystem.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryManager _categoryManager;

        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }


        //[HttpGet]
        //public IActionResult Index() //getall
        //{
        //    var categories = _categoryManager.GetAll();
        //    return View(categories);
        //}

        //[HttpGet]
        //[Route("Details/{id}")]
        //public IActionResult Details(int id) //get by id
        //{
        //    var category = _categoryManager.GetbyId(id);
        //    if (category == null)
        //    {
        //        return NotFound(); 
        //    }
        //    return View(category); 
        //}


        [HttpGet]
        [Route("Category/Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryAddDto categoryAddDto)
        {

            if (ModelState.IsValid)
            {
                _categoryManager.Add(categoryAddDto);
                return RedirectToAction("Index", "Home");
            }
            return View(categoryAddDto); 
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var category = _categoryManager.GetbyId(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category); 
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public IActionResult Edit(int id, CategoryUpdateDto categoryUpdateDto)
        {
            if (id != categoryUpdateDto.CategoryId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _categoryManager.Update(categoryUpdateDto);
                return RedirectToAction("Index"); 
            }
            return View(categoryUpdateDto); 
        }

        [HttpPost]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _categoryManager.Delete(id);
            return RedirectToAction("Index");
        }
    }
}

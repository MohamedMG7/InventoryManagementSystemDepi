using Microsoft.AspNetCore.Mvc;
using InventoryManagementSystem.BLL.Manager.UserManager;
using InventoryManagementSystem.BLL.Dto.UserDtos;
using System.Collections.Generic;

namespace InventoryManagementSystem.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var users = _userManager.GetAll();
            return View(users);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Details(int id)
        {
            var user = _userManager.GetbyId(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserAddDto userAddDto)
        {
            if (ModelState.IsValid)
            {
                _userManager.Add(userAddDto);
                return RedirectToAction("Index");
            }
            return View(userAddDto);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Edit(int id, UserUpdateDto userUpdateDto)
        {
            if (id != userUpdateDto.Id)
            {
                return BadRequest();
            }
            _userManager.Update(userUpdateDto);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _userManager.Delete(id);
            return RedirectToAction("Index");
        }
    }
}

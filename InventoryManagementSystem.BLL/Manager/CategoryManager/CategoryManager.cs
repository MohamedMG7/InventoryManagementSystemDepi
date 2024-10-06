using InventoryManagementSystem.BLL.Dto.CategoryDtos;
using InventoryManagementSystem.DAL.Reposatiries;
using InventoryManagementSystem.DAL.Data.Models;
using InventoryManagementSystem.BLL.Dto.UserDtos;

namespace InventoryManagementSystem.BLL.Manager.CategoryManager
{
    public class CategoryManager : ICategoryManager
    {
        private readonly ICategoryRepo _categoryRepo;
        public CategoryManager(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        public void Add(CategoryAddDto categoryAddDto)
        {
            var categoryModel = new Category{ 
                Name = categoryAddDto.Name,
                Description = categoryAddDto.Description
            };

            _categoryRepo.Add(categoryModel);
            _categoryRepo.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = _categoryRepo.GetbyID(id);
            _categoryRepo.Delete(category);
            _categoryRepo.SaveChanges();
        }

        public IEnumerable<CategoryReadDto> GetAll()
        {
            var categories = _categoryRepo.GetAll();
            var categoryList = categories.Select(x => new CategoryReadDto
            {
                CategoryId = x.CategoryId,
                Name = x.Name,
                Description = x.Description
                
            });
            return categoryList;
        }

        public CategoryReadDto GetbyId(int id)
        {
            var categoryModel = _categoryRepo.GetbyID(id);
            CategoryReadDto categoryRead = new CategoryReadDto { 
                CategoryId = categoryModel.CategoryId,
                Name = categoryModel.Name,  
                Description = categoryModel.Description
            };
            return categoryRead;
        }

        public void SaveChanges()
        {
            _categoryRepo.SaveChanges();
        }

        public void Update(CategoryUpdateDto categoryUpdateDto)
        {
            var Category = _categoryRepo.GetbyID(categoryUpdateDto.CategoryId);
            Category.CategoryId = categoryUpdateDto.CategoryId;
            Category.Name = categoryUpdateDto.Name;
            Category.Description = categoryUpdateDto.Description;
            _categoryRepo.Update(Category);
            _categoryRepo.SaveChanges();
        }
    }
}

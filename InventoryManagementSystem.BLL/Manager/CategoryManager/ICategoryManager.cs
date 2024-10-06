
using InventoryManagementSystem.BLL.Dto.CategoryDtos;

namespace InventoryManagementSystem.BLL.Manager.CategoryManager
{
    public interface ICategoryManager
    {
        IEnumerable<CategoryReadDto> GetAll();
        CategoryReadDto GetbyId(int id);
        void Add(CategoryAddDto categoryAddDto);
        void Update(CategoryUpdateDto categoryUpdateDto);
        void Delete(int id);
        void SaveChanges();
    }
}

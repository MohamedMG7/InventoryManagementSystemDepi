
using InventoryManagementSystem.BLL.Dto;
using InventoryManagementSystem.BLL.Dto.UserDtos;

namespace InventoryManagementSystem.BLL.Manager.UserManager
{
    public interface IAdminUserManager
    {
        IEnumerable<AdminUserReadDto> GetAll();
        AdminUserReadDto GetbyId(int id);
        void Add(UserAddDto UserAddDto);
        void Update(UserUpdateDto UserUpdateDto);
        void Delete(int id);
        void SaveChanges();
    }
}

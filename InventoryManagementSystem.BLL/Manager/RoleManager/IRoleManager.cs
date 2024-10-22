
using Microsoft.AspNetCore.Identity;

namespace InventoryManagementSystem.BLL.Manager.RoleManager
{
    public interface IRoleManager
    {
        Task<bool> CreateRoleAsync(string roleName);
        Task<bool> DeleteRoleAsync(string roleName);
        Task<IEnumerable<IdentityRole<int>>> GetAllRolesAsync();
    }
}

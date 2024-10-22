
using Microsoft.AspNetCore.Identity;

namespace InventoryManagementSystem.BLL.Manager.RoleManager
{
    public class RoleManager : IRoleManager
    {
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public RoleManager(RoleManager<IdentityRole<int>> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<bool> CreateRoleAsync(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
            {
                return false;
            }

            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (roleExists)
            {
                return false;
            }

            var result = await _roleManager.CreateAsync(new IdentityRole<int> { Name = roleName, NormalizedName = roleName.ToUpper() });
            return result.Succeeded;
        }

        public async Task<bool> DeleteRoleAsync(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                return false;
            }

            var result = await _roleManager.DeleteAsync(role);
            return result.Succeeded;
        }

        public async Task<IEnumerable<IdentityRole<int>>> GetAllRolesAsync()
        {
            return _roleManager.Roles;
        }
    }
}


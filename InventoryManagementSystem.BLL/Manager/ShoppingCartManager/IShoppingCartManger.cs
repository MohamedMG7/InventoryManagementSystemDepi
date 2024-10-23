using InventoryManagementSystem.BLL.Dto.ShoopinhCartDto;
using InventoryManagementSystem.BLL.Dto.ShoppingCartDto;

namespace InventoryManagementSystem.BLL.Manager.ShoppingCartManager
{
    public interface IShoppingCartManger
    {
        IEnumerable<ShoppingCartReadDto> GetAll();
        ShoppingCartReadDto GetbyId(int id);
        void Add(ShoppingCartAddDto ShoopingAddDto);
        void Delete(int id);
        void SaveChanges();
		IEnumerable<AdminShoppingCartReadDto> GetAllForAdmin();
	}
}

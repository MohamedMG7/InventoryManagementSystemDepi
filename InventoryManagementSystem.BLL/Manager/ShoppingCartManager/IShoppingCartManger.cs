using InventoryManagementSystem.BLL.Dto.ShoopinhCartDto;

namespace InventoryManagementSystem.BLL.Manager.ShoppingCartManager
{
    public interface IShoppingCartManger
    {
        IEnumerable<ShoppingCartReadDto> GetAll();
        ShoppingCartReadDto GetbyId(int id);
        void Add(ShoppingCartAddDto ShoopingAddDto);
        void Delete(int id);
        void SaveChanges();
    }
}

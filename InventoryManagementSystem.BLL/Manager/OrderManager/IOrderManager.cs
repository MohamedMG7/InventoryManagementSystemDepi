using InventoryManagementSystem.BLL.Dto.OrderDtos;

namespace InventoryManagementSystem.BLL.Manager.OrderManager
{
	public interface IOrderManager
	{
		IEnumerable<OrderReadDto> GetAll();
		OrderReadDto GetbyId(int id);
		void Add(OrderAddDto OrderAddDto);
		//ReadOrderWithProductsDto GetOrderWithProductsData(int OrderId);
		void Delete(int id);
		void SaveChanges();

        #region Reports
        IEnumerable<OrderReadDto> GetOrdersByDay(DateTime date);
        #endregion

    }
}

using InventoryManagementSystem.BLL.Dto.OrderDtos;
using InventoryManagementSystem.BLL.Dto.PaymentDtos;

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
	}
}

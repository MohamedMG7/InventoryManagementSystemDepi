using InventoryManagementSystem.BLL.Dto.OrderProductDtos;

namespace InventoryManagementSystem.BLL.Manager.OrderProductManager
{
	public interface IOrderProductManager
	{
		IEnumerable<OrderProductReadDto> GetAll();
		OrderProductReadDto GetbyId(int Orderid, int ProductId);
		void Add(OrderProductAddDto orderProductAddDto);
		void Delete(int Orderid, int ProductId);
		void SaveChanges();
	}
}

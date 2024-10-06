//there should be endpoint for reading order and its product
using InventoryManagementSystem.BLL.Dto;
using InventoryManagementSystem.BLL.Dto.OrderDtos;
using InventoryManagementSystem.DAL.Reposatiries;
using InventoryManagementSystem.DAL.Data.Models;
using InventoryManagementSystem.BLL.Dto.PaymentDtos;
using InventoryManagementSystem.BLL.Dto.OrderProductDtos;

namespace InventoryManagementSystem.BLL.Manager.OrderManager
{
	public class OrderManager : IOrderManager
	{
		private readonly IOrderRepo _orderRepo;
        public OrderManager(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }

		public void Add(OrderAddDto OrderAddDto)
		{
			var orderModel = new Order
			{
				TrackingNumber = OrderAddDto.TrackingNumber,
				UserId = OrderAddDto.UserId,
				Date = DateTime.Now
			};
			
			_orderRepo.Add(orderModel);
			_orderRepo.SaveChanges();
		}

		public void Delete(int id)
		{
			var OrderModel = _orderRepo.GetbyID(id);
			_orderRepo.Delete(OrderModel);
			_orderRepo.SaveChanges();
		}

		public IEnumerable<OrderReadDto> GetAll()
		{
			var orders = _orderRepo.GetAll();
			var orderssList = orders.Select(x => new OrderReadDto
			{
				OrderId = x.OrderId,
				TrackingNumber = x.TrackingNumber,
				UserId = x.UserId,
				Date = x.Date
				
			});
			return orderssList;
		}

		public OrderReadDto GetbyId(int id)
		{
			var orderModel = _orderRepo.GetbyID(id);
			OrderReadDto orderReadDto = new OrderReadDto
			{
				OrderId = orderModel.OrderId,
				TrackingNumber = orderModel.TrackingNumber,
				UserId = orderModel.UserId
			};

			return orderReadDto;
		}

		public void SaveChanges()
		{
			_orderRepo.SaveChanges();
		}
	}
}

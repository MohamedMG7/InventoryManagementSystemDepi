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
				Date = DateTime.Now,
				OrderProducts = new List<OrderProduct>()
			};

			foreach (var productDto in OrderAddDto.Products)
			{
				var orderProduct = new OrderProduct
				{
					// Set the OrderId to associate this product with the order
					OrderId = orderModel.OrderId, // Make sure OrderId is available here; set after order save
					ProductId = productDto.ProductId,
					Quantity = productDto.Quantity,
					PriceAtPurchase = productDto.PriceAtPurchase // Use PriceAtPurchase from DTO
				};

				orderModel.OrderProducts.Add(orderProduct);
			}

			_orderRepo.Add(orderModel);
			_orderRepo.SaveChanges();

			foreach (var orderProduct in orderModel.OrderProducts)
			{
				orderProduct.OrderId = orderModel.OrderId; // Ensure OrderId is set correctly
			}
		}

		public void Delete(int id)
		{
			var OrderModel = _orderRepo.GetbyID(id);
			if (OrderModel != null && !OrderModel.isDeleted) {
				_orderRepo.Delete(OrderModel);
				_orderRepo.SaveChanges();
			}
			
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

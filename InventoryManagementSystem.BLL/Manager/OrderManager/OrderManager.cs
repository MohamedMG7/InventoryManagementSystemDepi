//there should be endpoint for reading order and its product
using InventoryManagementSystem.BLL.Dto;
using InventoryManagementSystem.BLL.Dto.OrderDtos;
using InventoryManagementSystem.DAL.Reposatiries;
using InventoryManagementSystem.DAL.Data.Models;
using InventoryManagementSystem.BLL.Dto.PaymentDtos;
using InventoryManagementSystem.BLL.Dto.OrderProductDtos;
using Microsoft.AspNetCore.Authorization;

namespace InventoryManagementSystem.BLL.Manager.OrderManager
{
	public class OrderManager : IOrderManager
	{
		private readonly IOrderRepo _orderRepo;
		private readonly IProductVariantRepo _productVariantRepo;
		public OrderManager(IOrderRepo orderRepo, IProductVariantRepo productVariantRepo)
        {
            _orderRepo = orderRepo;
			_productVariantRepo = productVariantRepo;	
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

			#region Validate Availability
			foreach (var productDto in OrderAddDto.Products)
			{
				
				var productVariant = _productVariantRepo.GetbyID(productDto.ProductVariantId);

				if (productVariant == null)
				{
					throw new InvalidOperationException($"Product variant with ID {productDto.ProductVariantId} does not exist.");
				}

				
				if (productVariant.QuantityInStock < productDto.Quantity)
				{
					throw new InvalidOperationException($"Insufficient stock for product variant ID {productDto.ProductVariantId}. Available: {productVariant.QuantityInStock}, requested: {productDto.Quantity}.");
				}
			}
			#endregion


			foreach (var productDto in OrderAddDto.Products)
			{
				var orderProduct = new OrderProduct
				{
					OrderId = orderModel.OrderId, // Make sure OrderId is available here; set after order save
					ProductVariantId = productDto.ProductVariantId, // Updated to use ProductVariantId
					Quantity = productDto.Quantity,
					PriceAtPurchase = productDto.PriceAtPurchase // Use PriceAtPurchase from DTO
				};

				orderModel.OrderProducts.Add(orderProduct);
			}

			_orderRepo.Add(orderModel);
			//_orderRepo.SaveChanges();

			// Ensure OrderId is set correctly after adding the order
			foreach (var orderProduct in orderModel.OrderProducts)
			{
				orderProduct.OrderId = orderModel.OrderId; // Ensure OrderId is set correctly
			}

			// Update stock for each product variant
			foreach (var orderProduct in orderModel.OrderProducts)
			{
				var productVariant = _productVariantRepo.GetbyID(orderProduct.ProductVariantId); // Updated to use ProductVariantId

				if (productVariant != null)
				{
					productVariant.QuantityInStock -= orderProduct.Quantity;
					_productVariantRepo.Update(productVariant);
				}
			}
			_orderRepo.SaveChanges();
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

        #region Reports
        public IEnumerable<OrderReadDto> GetOrdersByDay(DateTime date)
        {
            // Get all orders and filter by the provided date
            var orders = _orderRepo.GetAll()
                                   .Where(o => o.Date.Date == date.Date)
                                   .Select(x => new OrderReadDto
                                   {
                                       OrderId = x.OrderId,
                                       TrackingNumber = x.TrackingNumber,
                                       UserId = x.UserId,
                                       Date = x.Date
                                   });

            return orders;
        }
        #endregion
    }
}

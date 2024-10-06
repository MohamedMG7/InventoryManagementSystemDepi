using InventoryManagementSystem.BLL.Dto.OrderProductDtos;
using InventoryManagementSystem.DAL.Reposatiries;
using InventoryManagementSystem.DAL.Data.Models;
using InventoryManagementSystem.BLL.Dto.PaymentDtos;
namespace InventoryManagementSystem.BLL.Manager.OrderProductManager
{
	public class OrderProductManager : IOrderProductManager
	{
		private readonly IOrderProductRepo _orderProductRepo;
        public OrderProductManager(IOrderProductRepo orderProductRepo)
        {
            _orderProductRepo = orderProductRepo;
        }

		public void Add(OrderProductAddDto orderProductAddDto)
		{
			var orderProductModel = new OrderProduct
			{
				OrderId = orderProductAddDto.OrderId,
				ProductId = orderProductAddDto.ProductId,
				Quantity = orderProductAddDto.Quantity,
				PriceAtPurchase = orderProductAddDto.PriceAtPurchase
			};
			_orderProductRepo.Add(orderProductModel);
			_orderProductRepo.SaveChanges();
		}

		public void Delete(int OrderId, int ProductId)
		{
			var orderProductModel = _orderProductRepo.GetbyID(OrderId,ProductId);
			_orderProductRepo.Delete(orderProductModel);
			_orderProductRepo.SaveChanges();
		}

		public IEnumerable<OrderProductReadDto> GetAll()
		{
			var orderProducts = _orderProductRepo.GetAll();
			var orderProductsList = orderProducts.Select(x => new OrderProductReadDto
			{
				ProductId = x.ProductId,
				PriceAtPurchase = x.PriceAtPurchase,
				Quantity = x.Quantity,
				ProductName = x.product.Name,
				OrderId = x.OrderId
			});
			return orderProductsList;
		}

		public OrderProductReadDto GetbyId(int OrderId, int ProductId)
		{
			var paymentModel = _orderProductRepo.GetbyID(OrderId, ProductId);
			OrderProductReadDto orderProductReadDto = new OrderProductReadDto
			{
				ProductId = paymentModel.ProductId,
				PriceAtPurchase = paymentModel.PriceAtPurchase,
				Quantity = paymentModel.Quantity,
				ProductName = paymentModel.product.Name,
				OrderId = paymentModel.OrderId
			};

			return orderProductReadDto;
		}

		public void SaveChanges()
		{
			_orderProductRepo.SaveChanges();
		}
	}
}

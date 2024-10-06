using InventoryManagementSystem.DAL.Data.Models;
using InventoryManagementSystem.BLL.Dto.CartProductDtos;
using InventoryManagementSystem.DAL.Reposatiries;
using InventoryManagementSystem.BLL.Dto.OrderDtos;

namespace InventoryManagementSystem.BLL.Manager.CartProductManager
{
	public class CartProductManager : ICartProductManager
	{
		private readonly ICartProductRepo _cartProductRepo;
        public CartProductManager(ICartProductRepo cartProductRepo)
        {
            _cartProductRepo = cartProductRepo;
        }
        public void Add(CartProductAddDto cartproductAddDto)
		{
			var cartProductModel = new CartProduct { 
				ShoppingCartId = cartproductAddDto.ShoppingCartId,
				ProductId = cartproductAddDto.ProductId,
				Quantity = cartproductAddDto.Quantity
			};
			_cartProductRepo.Add(cartProductModel);
			_cartProductRepo.SaveChanges();
		}

		public void Delete(int ShoppingCartid, int ProductId)
		{
			var cartProductModel = _cartProductRepo.GetbyID(ShoppingCartid,ProductId);
			_cartProductRepo.Delete(cartProductModel);
			_cartProductRepo.SaveChanges();
		}

		public IEnumerable<CartProductReadDto> GetAll()
		{
			var cartProducts = _cartProductRepo.GetAll();
			var cartProductsList = cartProducts.Select(x => new CartProductReadDto
			{
				ProductId=x.ProductId,
				Quantity = x.Quantity,
				ProductName = x.product.Name,
				ShoppingCartId = x.ShoppingCartId

			});
			return cartProductsList;
		}

		public CartProductReadDto GetbyId(int ShoppingCartid, int ProductId)
		{
			var cartProductsModel = _cartProductRepo.GetbyID(ShoppingCartid,ProductId);
			CartProductReadDto cartProductReadDto = new CartProductReadDto
			{
				ProductId = cartProductsModel.ProductId,
				Quantity = cartProductsModel.Quantity,
				ProductName = cartProductsModel.product.Name,
				ShoppingCartId = cartProductsModel.ShoppingCartId
			};

			return cartProductReadDto;
		}

		public void SaveChanges()
		{
			_cartProductRepo.SaveChanges();
		}

		public void Update(CartProductUpdateDto cartproductupdatedto)
		{
			var cartProductModel = _cartProductRepo.GetbyID(cartproductupdatedto.ShoppingCartId, cartproductupdatedto.ProductId);
			cartProductModel.Quantity = cartproductupdatedto.Quantity;
			_cartProductRepo.Update(cartProductModel);
			_cartProductRepo.SaveChanges();
		}
	}
}

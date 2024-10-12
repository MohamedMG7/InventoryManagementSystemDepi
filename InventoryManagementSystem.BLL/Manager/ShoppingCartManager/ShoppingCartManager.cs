using InventoryManagementSystem.BLL.Dto.ShoopinhCartDto;
using InventoryManagementSystem.BLL.Dto.UserDtos;
using InventoryManagementSystem.DAL.Data.Models;
using InventoryManagementSystem.DAL.Reposatiries;
using Microsoft.AspNet.Identity;

namespace InventoryManagementSystem.BLL.Manager.ShoppingCartManager
{
    public class ShoppingCartManager : IShoppingCartManger
    {
        private readonly IShoppingCartRepo _shoppingCartRepo;

        public ShoppingCartManager(IShoppingCartRepo shoppingCartRepo)
        {
           _shoppingCartRepo = shoppingCartRepo;
        }
        void IShoppingCartManger.Add(ShoppingCartAddDto ShoppingAddDto)
        {
            var shoppingcartModel = new ShoppingCart
            {
                UserId =  ShoppingAddDto.UserId        
            };

            _shoppingCartRepo.Add(shoppingcartModel);
            _shoppingCartRepo.SaveChanges();
        }

        void IShoppingCartManger.Delete(int id)
        {
            var cart = _shoppingCartRepo.GetbyID(id);
			if (cart != null && !cart.isDeleted)
			{
				_shoppingCartRepo.Delete(cart);
				_shoppingCartRepo.SaveChanges();
			}
		}

        IEnumerable<ShoppingCartReadDto> IShoppingCartManger.GetAll()
        {
            var ShoppingCarts = _shoppingCartRepo.GetAll();
            var ShoppingCartsList = ShoppingCarts.Select(x => new ShoppingCartReadDto
            {
                CartId = x.ShoppingCartId,
                UserId = x.UserId,
                TotalPrice = x.TotalPrice
            });
            return ShoppingCartsList;
        }

        ShoppingCartReadDto IShoppingCartManger.GetbyId(int id)
        {
            var ShoppingCartModel = _shoppingCartRepo.GetbyID(id);
            ShoppingCartReadDto ShoppingCartReadDto = new ShoppingCartReadDto
            {
                UserId = ShoppingCartModel.UserId,
                CartId = ShoppingCartModel.ShoppingCartId,
                TotalPrice= ShoppingCartModel.TotalPrice
            };

            return ShoppingCartReadDto;
        }

        void IShoppingCartManger.SaveChanges()
        {
            _shoppingCartRepo.SaveChanges();
        }

    }
}

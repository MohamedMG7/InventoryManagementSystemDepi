using InventoryManagementSystem.DAL.Data.Models;
using InventoryManagementSystem.BLL.Dto.CartProductDtos;
using InventoryManagementSystem.DAL.Reposatiries;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagementSystem.BLL.Manager.CartProductManager
{
    public class CartProductManager : ICartProductManager
    {
        private readonly ICartProductRepo _cartProductRepo;

        public CartProductManager(ICartProductRepo cartProductRepo)
        {
            _cartProductRepo = cartProductRepo;
        }

        public void Add(CartProductAddDto cartProductAddDto)
        {
            var cartProductModel = new CartProduct
            {
                ShoppingCartId = cartProductAddDto.ShoppingCartId,
                ProductId = cartProductAddDto.ProductId,
                Quantity = cartProductAddDto.Quantity
            };

            _cartProductRepo.Add(cartProductModel);
            SaveChanges();
        }

        public void Delete(int shoppingCartId, int productId)
        {
            var cartProductModel = _cartProductRepo.GetbyID(shoppingCartId, productId);
            if (cartProductModel != null && !cartProductModel.isDeleted)
            {
                _cartProductRepo.Delete(cartProductModel);
                SaveChanges();
            }
            else
            {
                // Optionally log or throw an exception
            }
        }

        public IEnumerable<CartProductReadDto> GetAll()
        {
            var cartProducts = _cartProductRepo.GetAll();
            return cartProducts.Select(x => new CartProductReadDto
            {
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                ProductName = x.product.Name,
                ShoppingCartId = x.ShoppingCartId
            });
        }

        public CartProductReadDto GetbyId(int shoppingCartId, int productId)
        {
            var cartProductModel = _cartProductRepo.GetbyID(shoppingCartId, productId);
            if (cartProductModel == null)
            {
                return null; // Handle the case where the cart product was not found
            }

            return new CartProductReadDto
            {
                ProductId = cartProductModel.ProductId,
                Quantity = cartProductModel.Quantity,
                ProductName = cartProductModel.product.Name,
                ShoppingCartId = cartProductModel.ShoppingCartId
            };
        }

        public void Update(CartProductUpdateDto cartProductUpdateDto)
        {
            var cartProductModel = _cartProductRepo.GetbyID(cartProductUpdateDto.ShoppingCartId, cartProductUpdateDto.ProductId);
            if (cartProductModel != null)
            {
                cartProductModel.Quantity = cartProductUpdateDto.Quantity;
                _cartProductRepo.Update(cartProductModel);
                SaveChanges();
            }
            else
            {
                // Handle the case where the cart product was not found
            }
        }

        public void SaveChanges()
        {
            _cartProductRepo.SaveChanges();
        }
    }
}

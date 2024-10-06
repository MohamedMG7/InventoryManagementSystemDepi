using InventoryManagementSystem.BLL.Dto;
using InventoryManagementSystem.DAL.Data.Models;
using InventoryManagementSystem.DAL.Reposatiries;

using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.BLL.Manager
{
	public class ProductManager : IProductManager
	{
		private readonly IProductRepo _productRepo;
        public ProductManager(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }


        public void Add(ProductAddDto productAddDto)
		{
			var ProductModel = new Product
			{
				Name = productAddDto.Name,
				Description = productAddDto.Description,
				Price = productAddDto.Price,
				ImageUrl = productAddDto.ImageUrl,
				CompanyId = productAddDto.CompanyId,
				CategoryId = productAddDto.CategoryId,
				MinimumStockToRequest = productAddDto.MinimumStockToRequest,
				DiscountPrecentage = productAddDto.DiscountPrecentage,
			};
			_productRepo.Add(ProductModel);
			_productRepo.SaveChanges();
		}

		public void Delete(int id)
		{
			var product = _productRepo.GetbyID(id);
			_productRepo.Delete(product);
			_productRepo.SaveChanges();
		}

		public IEnumerable<ProductReadDto> GetAll()
		{
			var productModel = _productRepo.GetAll();
			var ProductDtoList = productModel.Select(x => new ProductReadDto(){ 
				ProductId = x.ProductId,
				Name = x.Name,
				Description = x.Description,
				Price = x.Price,
				ImageUrl = x.ImageUrl,
				CompanyName = x.company.Name,
				CategoryName = x.category.Name,
				MinimumStockToRequest = x.MinimumStockToRequest,
				DiscountPrecentage= x.DiscountPrecentage,
			});
			return ProductDtoList;
		}

		public ProductReadDto GetbyId(int id)
		{
            var ProductModel = _productRepo.GetbyID(id);
			ProductReadDto productReadDto = new ProductReadDto { 
				ProductId = ProductModel.ProductId,
				Name = ProductModel.Name,
				Description = ProductModel.Description,
				Price = ProductModel.Price,
				ImageUrl = ProductModel.ImageUrl,
				CompanyName = ProductModel.company?.Name,
				CategoryName = ProductModel.category?.Name,
				MinimumStockToRequest = ProductModel.MinimumStockToRequest,
				DiscountPrecentage= ProductModel.DiscountPrecentage
			};
			return productReadDto;
		}

		public void SaveChanges()
		{
			_productRepo.SaveChanges();
		}

		public void Update(ProductUpdateDto product)
		{
			var productUpdate = _productRepo.GetbyID(product.Id);
			productUpdate.Name = product.Name;
			productUpdate.Description = product.Description;
			productUpdate.Price = product.Price;
			productUpdate.ImageUrl = product.ImageUrl;
			_productRepo.Update(productUpdate);
			_productRepo.SaveChanges();
		}
	}
}

using InventoryManagementSystem.DAL.Reposatiries;
using InventoryManagementSystem.BLL.Dto.ProductVariantDtos;
using InventoryManagementSystem.DAL.Data.Models;
using InventoryManagementSystem.BLL.Dto;

namespace InventoryManagementSystem.BLL.Manager.ProductVariantManager
{
	public class ProductVariantManager : IProductVariantManager
	{
		private readonly IProductVariantRepo _productVariantRepo;
        public ProductVariantManager(IProductVariantRepo productVariantRepo)
        {
            _productVariantRepo = productVariantRepo;
        }
        public void Add(ProductVariantAddDto productVariantAddDto)
		{
			var productVariantModel = new ProductVariant { 
				ProductId = productVariantAddDto.ProductId,
				Size = productVariantAddDto.Size,
				Color = productVariantAddDto.Color,
				Dimensions = productVariantAddDto.Dimensions,
				QuantityInStock = productVariantAddDto.QuantityInStock,

			};
			_productVariantRepo.Add(productVariantModel);
			_productVariantRepo.SaveChanges();
		}

		public void Delete(int id)
		{
			var productVariantModel = _productVariantRepo.GetbyID(id);
			_productVariantRepo.Delete(productVariantModel);
			_productVariantRepo.SaveChanges();
		}

		public IEnumerable<ProductVariantReadDto> GetAll()
		{
			var productVariantModel = _productVariantRepo.GetAll();
			var ProductVariantDtoList = productVariantModel.Select(x => new ProductVariantReadDto()
			{
				ProductId = x.ProductId,
				ProductVariantId = x.ProductVariantId,
				QuantityInStock = x.QuantityInStock,
				Dimensions = x.Dimensions,
				Color = x.Color,
				Size = x.Size,
				Weight = x.Weight
			});
			return ProductVariantDtoList;
		}

		public ProductVariantReadDto GetbyId(int id)
		{
			var ProductVariantModel = _productVariantRepo.GetbyID(id);
			ProductVariantReadDto productVariantReadDto = new ProductVariantReadDto
			{
				ProductId = ProductVariantModel.ProductId,
				ProductVariantId = ProductVariantModel.ProductVariantId,
				QuantityInStock = ProductVariantModel.QuantityInStock,
				Dimensions = ProductVariantModel.Dimensions,
				Color = ProductVariantModel.Color,
				Size = ProductVariantModel.Size,
				Weight = ProductVariantModel.Weight
			};
			return productVariantReadDto;
		}

		public void SaveChanges()
		{
			_productVariantRepo.SaveChanges();
		}

		public void Update(ProductVariantUpdateDto productvariantupdatedto)
		{
			var productVariantUpdate = _productVariantRepo.GetbyID(productvariantupdatedto.ProductVariantId);
			productVariantUpdate.Color = productvariantupdatedto.Color;
			productVariantUpdate.Weight = productvariantupdatedto.Weight;
			productVariantUpdate.Size = productvariantupdatedto.Size;
			productVariantUpdate.Dimensions = productvariantupdatedto.Dimensions;
			_productVariantRepo.Update(productVariantUpdate);
			_productVariantRepo.SaveChanges();
		}
	}
}

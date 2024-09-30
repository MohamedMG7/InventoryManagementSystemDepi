using InventoryManagementSystem.BLL.Dto;
using InventoryManagementSystem.DAL.Data.Models;
using InventoryManagementSystem.DAL.Reposatiries;

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

		public IEnumerable<Product> GetAll()
		{
			throw new NotImplementedException();
		}

		public ProductReadDto GetbyId(int id)
		{
			var ProductModel = _productRepo.GetbyID(id);
			ProductReadDto product = new ProductReadDto { 
				ProductId = ProductModel.ProductId,
				Name = ProductModel.Name,
				Description = ProductModel.Description,
				Price = ProductModel.Price,
				ImageUrl = ProductModel.ImageUrl,
				CompanyName = ProductModel.CompanyName,
				CategoryName = ProductModel.CategoryName,
			};

		}

		public void SaveChanges()
		{
			_productRepo.SaveChanges();
		}

		public void Update(Product product)
		{
			throw new NotImplementedException();
		}
	}
}

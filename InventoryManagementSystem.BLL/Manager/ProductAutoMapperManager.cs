using AutoMapper;
using InventoryManagementSystem.BLL.Dto;
using InventoryManagementSystem.DAL.Data.Models;
using InventoryManagementSystem.DAL.Reposatiries;

namespace InventoryManagementSystem.BLL.Manager
{
    public class ProductAutoMapperManager : IProductManager
    {
        private readonly IMapper _mapper;
        private readonly IProductRepo _productRepo;
        public ProductAutoMapperManager(IProductRepo productRepo, IMapper mapper)
        {
            _mapper = mapper;
            _productRepo = productRepo;
        }

        public void Add(ProductAddDto productAddDto)
        {
            _productRepo.Add(_mapper.Map<Product>(productAddDto));
            _productRepo.SaveChanges();
        }

        public void Delete(int id)
        {
            var productModel = _productRepo.GetbyID(id);
            _productRepo.Delete(productModel);
            _productRepo.SaveChanges();
        }

        public IEnumerable<ProductReadDto> GetAll()
        {
            return _mapper.Map<List<ProductReadDto>>(_productRepo.GetAll());
        }

        public ProductReadDto GetbyId(int id)
        {
            return _mapper.Map<ProductReadDto>(_productRepo.GetbyID(id));
        }

        public void SaveChanges()
        {
            _productRepo.SaveChanges();
        }

        public void Update(ProductUpdateDto productUpdateDto)
        {
            _productRepo.Update(_mapper.Map(productUpdateDto, _productRepo.GetbyID(productUpdateDto.Id)));
            _productRepo.SaveChanges();
        }
    }
}

using AutoMapper;
using InventoryManagementSystem.BLL.Dto;
using InventoryManagementSystem.DAL.Data.Models;

namespace InventoryManagementSystem.BLL.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductAddDto>().ReverseMap();
            CreateMap<Product, ProductUpdateDto>().ReverseMap();
            CreateMap<Product, ProductReadDto>().ReverseMap();
        }
    }
}

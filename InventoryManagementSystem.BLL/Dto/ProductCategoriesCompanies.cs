using InventoryManagementSystem.BLL.Dto.CategoryDtos;
using InventoryManagementSystem.BLL.Dto.CompanyDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.BLL.Dto
{
    internal class ProductCategoriesCompanies
    {
        public ProductAddDto Product { get; set; }
        public List<CategoryReadDto> Categories { get; set; }
        public List<CompanyReadDto> Companies { get; set; }
    }
}

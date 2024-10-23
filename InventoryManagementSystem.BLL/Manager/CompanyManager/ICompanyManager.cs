
using InventoryManagementSystem.BLL.Dto.CompanyDtos;

namespace InventoryManagementSystem.BLL.Manager.CompanyManager
{
	public interface ICompanyManager 
	{
		IEnumerable<CompanyReadDto> GetAll();
		CompanyReadDto GetbyId(int id);
		void Add(CompanyAddDto companyAddDto);
		void Update(CompanyUpdateDto companyupdatedto);
		void Delete(int id);
		void SaveChanges();
		IEnumerable<ActiveCompanyReadDto> GetAllActive();
	}
}

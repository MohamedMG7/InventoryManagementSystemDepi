
using InventoryManagementSystem.BLL.Dto.CompanyDtos;
using InventoryManagementSystem.DAL.Reposatiries;
using InventoryManagementSystem.DAL.Data.Models;
using InventoryManagementSystem.BLL.Dto.OrderDtos;

namespace InventoryManagementSystem.BLL.Manager.CompanyManager
{
	public class CompanyManager : ICompanyManager
	{
		private readonly ICompanyRepo _companyRepo;
        public CompanyManager(ICompanyRepo companyRepo)
        {
            _companyRepo = companyRepo;
        }
        public void Add(CompanyAddDto companyAddDto)
		{
			var companyModel = new Company { 
				Name = companyAddDto.Name,
				State = companyAddDto.State,
				City = companyAddDto.City,
				Street = companyAddDto.Street,
				PhoneNumber = companyAddDto.PhoneNumber
			};

			_companyRepo.Add(companyModel);
			_companyRepo.SaveChanges();
		}

		public void Delete(int id)
		{
			var companyModel = _companyRepo.GetbyID(id);
			if (companyModel != null && !companyModel.isDeleted) {
				_companyRepo.Delete(companyModel);
				_companyRepo.SaveChanges();
			}
			
		}

		public IEnumerable<ActiveCompanyReadDto> GetAllActive()
		{
			var companies = _companyRepo.GetAllActive();
			var companiesList = companies.Select(x => new ActiveCompanyReadDto
			{
				CompanyId = x.CompanyId,
				Name = x.Name,
				State = x.State,
				City = x.City,
				Street = x.Street,
				PhoneNumber = x.PhoneNumber
			});
			return companiesList;
		}

		public IEnumerable<CompanyReadDto> GetAll()
		{
			var companies = _companyRepo.GetAll();
			var companiesList = companies.Select(x => new CompanyReadDto
			{
				CompanyId = x.CompanyId,
				Name = x.Name,
				State = x.State,
				City = x.City,
				Street = x.Street,
				PhoneNumber = x.PhoneNumber,
				isDeleted = x.isDeleted,
			});
			return companiesList;
		}

		public CompanyReadDto GetbyId(int id)
		{
			var companyModel = _companyRepo.GetbyID(id);
			CompanyReadDto companyReadDto = new CompanyReadDto
			{
				CompanyId = companyModel.CompanyId,
				Name = companyModel.Name,
				State = companyModel.State,
				City = companyModel.City,
				Street = companyModel.Street,
				PhoneNumber = companyModel.PhoneNumber,
				isDeleted = companyModel.isDeleted,
			};

			return companyReadDto;
		}

		public void SaveChanges()
		{
			_companyRepo.SaveChanges();
		}

		public void Update(CompanyUpdateDto companyupdatedto)
		{
			var companyUpdate = _companyRepo.GetbyID(companyupdatedto.CompanyId);
			companyUpdate.Name = companyupdatedto.Name;
			companyUpdate.State = companyupdatedto.State;
			companyUpdate.City = companyupdatedto.City;
			companyUpdate.Street = companyupdatedto.Street;
			companyUpdate.PhoneNumber = companyupdatedto.PhoneNumber;
			_companyRepo.Update(companyUpdate);
			_companyRepo.SaveChanges();
		}
	}
}

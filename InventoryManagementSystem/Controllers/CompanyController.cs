using InventoryManagementSystem.BLL.Dto.CompanyDtos;
using InventoryManagementSystem.BLL.Manager.CompanyManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(Roles = "Admin")]
	public class CompanyController : ControllerBase
	{
		private readonly ICompanyManager _companyManager;
		public CompanyController(ICompanyManager companyManager)
		{
			_companyManager = companyManager;
		}

		[HttpGet("Active")]
		public ActionResult<IEnumerable<ActiveCompanyReadDto>> GetAll()
		{
			return Ok(_companyManager.GetAllActive());
		}

		[HttpGet()]
		public ActionResult<IEnumerable<CompanyReadDto>> GetAllActive()
		{
			return Ok(_companyManager.GetAll());
		}

		[HttpGet]
		[Route("{id}")]
		public ActionResult GetById(int id)
		{
			return Ok(_companyManager.GetbyId(id));
		}

		[HttpPut]
		[Route("{id}")]
		public ActionResult Update(int id, CompanyUpdateDto companyUpdateDto)
		{
			if (id != companyUpdateDto.CompanyId)
			{
				return BadRequest();
			}
			_companyManager.Update(companyUpdateDto);
			return Ok();
		}

		[HttpDelete]
		[Route("{id}")]
		public ActionResult DeleteById(int id)
		{
			_companyManager.Delete(id);
			return NoContent();
		}

		[HttpPost]
		public ActionResult Add(CompanyAddDto companyAddDto)
		{
			_companyManager.Add(companyAddDto);
			return Ok(companyAddDto);

		}
	}
}

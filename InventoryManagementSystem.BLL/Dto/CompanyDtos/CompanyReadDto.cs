
namespace InventoryManagementSystem.BLL.Dto.CompanyDtos
{
	public class CompanyReadDto
	{
		public int CompanyId { get; set; }
		public string Name { get; set; }
		public string State { get; set; }
		public string City { get; set; }
		public string Street { get; set; }
		public string PhoneNumber { get; set; }
        public bool isDeleted { get; set; }
    }
}

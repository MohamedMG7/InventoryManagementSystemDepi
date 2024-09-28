
namespace InventoryManagementSystem.DAL.Data.Models
{
	public class Company
	{
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}

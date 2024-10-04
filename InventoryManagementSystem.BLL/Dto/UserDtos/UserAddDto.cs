

namespace InventoryManagementSystem.BLL.Dto.UserDtos
{
    public class UserAddDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }  // Plain password before hashing
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PhoneNumber { get; set; }
        public string UserType { get; set; }
    }
}

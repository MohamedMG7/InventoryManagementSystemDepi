

namespace InventoryManagementSystem.BLL.Dto.UserDtos
{
    public class AdminUserReadDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PhoneNumber { get; set; }
        public string UserType { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool isDeleted { get; set; }
    }
}

﻿

namespace InventoryManagementSystem.BLL.Dto.UserDtos
{
    public class UserUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PhoneNumber { get; set; }

        public string Password { get; set; }
    }
}

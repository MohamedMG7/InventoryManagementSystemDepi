using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.BLL.Dto.UserDtos
{
    public class VerifyResetPasswordDto
    {
        public string Email { get; set; }
        public string Token { get; set; }
    }
}

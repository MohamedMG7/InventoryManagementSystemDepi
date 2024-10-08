using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.BLL.Dto.Login
{
    public class LoginUser
    {
        [Required]
        public string UserName{ get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string PassWord { get; set; }

        public bool RememberMe { get; set; }
    }
}

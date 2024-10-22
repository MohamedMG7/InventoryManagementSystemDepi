using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.BLL.Dto.UserDtos
{
    public class ResetPasswordDto
    {
        [Required(ErrorMessage = "البريد الإلكتروني مطلوب.")]
        [EmailAddress(ErrorMessage = "البريد الإلكتروني غير صحيح.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "رمز إعادة تعيين كلمة المرور مطلوب.")]
        public string Token { get; set; }

        [Required(ErrorMessage = "كلمة المرور الجديدة مطلوبة.")]
        [StringLength(100, ErrorMessage = "يجب أن تكون كلمة المرور على الأقل {2} أحرف.", MinimumLength = 6)]
        public string NewPassword { get; set; }
    }
}

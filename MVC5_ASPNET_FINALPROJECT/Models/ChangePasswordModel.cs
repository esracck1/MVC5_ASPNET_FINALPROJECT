using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5_ASPNET_FINALPROJECT.Models
{
    public class ChangePasswordModel
    {
        [Required]
        [DisplayName("Eski Şifre")]
        public string OldPassword { get; set; }
        [Required]
        [DisplayName("Yeni Şifre")]
        [StringLength(16, MinimumLength = 5, ErrorMessage = "Şifreniz en az 5 karakter en fazla 16 karakter olmalıdır.")]
        public string NewPassword { get; set; }
        [Required]
        [DisplayName("Şifre Tekrarı")]
        [Compare("NewPassword",ErrorMessage ="Şifreler aynı değil") ]
        public string ConNewPassword { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Web.Models
{
    public class SigninInput
    {
        [Required]
        [Display(Name = "Email Adresi")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
        [Display(Name = "Beni Hatırla")]
        public bool isRemember { get; set; }
    }
}

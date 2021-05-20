using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Case_Deti.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Логин")]
        [DataType(DataType.Text)]
        [StringLength(32, ErrorMessage = "Логин должен содержать от {2} до {1} знаков.", MinimumLength = 8)]
        public string Login { get; set; }

        [Required]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        [StringLength(32, ErrorMessage = "Пароль должен содержать от {2} до {1} знаков.", MinimumLength = 4)]
        public string Password { get; set; }
    }
}

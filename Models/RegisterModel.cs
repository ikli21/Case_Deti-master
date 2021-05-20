using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Case_Deti.Models
{
    public class RegisterModel
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


        [Required]
        [Display(Name = "Имя")]
        [StringLength(64, ErrorMessage = "Имя должно содержать не менее {2} знаков и не более {1}.", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        [StringLength(64, ErrorMessage = "Фамилия должна содержать не менее {2} знаков и не более {1}.", MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Отчество")]
        [StringLength(64, ErrorMessage = "Отчество должно содержать не менее {2} знаков и не более {1}.", MinimumLength = 2)]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Возраст")]
        public int Age { get; set; }

        [Required]
        [Display(Name = "Зарегистрировать как организацию?")]
        public char Sex { get; set; }
    }
}

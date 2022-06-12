using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalFinancialManagement.Models
{
    public class Profile
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Не задано имя профиля")]
        public string ProfileName { get; set; }

        [Required(ErrorMessage = "Не задан логин")]
        public string Login { get; set; }

        public string Email { get; set; }

        [Required(ErrorMessage = "Не задан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не задан тип профиля")]
        public ProfileType ProfileType { get; set; }

        public bool DoubleAuthetication { get; set; }
    }
}

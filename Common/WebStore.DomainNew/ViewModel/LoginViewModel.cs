using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name ="Имя")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Пароль")]
        public string Password { get; set; }

        [Display(Name ="Запомнить меня")]
        public bool RememberMy { get; set; }

        /// <summary>
        /// Куда вернуть пользователя при успешной регистрации
        /// </summary>
        public string ReturnUrl { get; set; }
    }
}

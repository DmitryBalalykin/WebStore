using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.ViewModel
{
    public class RegisterUserViewModel
    {
        [Required(AllowEmptyStrings =false, ErrorMessage ="Имя является обязательным для заполнения")]
        [Display(Name ="Имя")]
        [StringLength(maximumLength:20,MinimumLength =2,ErrorMessage ="Имя должно быть не менее 2 символов но не более 20 символов")]
        [Remote("IsUserNameFree","Account", ErrorMessage ="Пользователь с таким именем уже существует!")]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле почта является обязательным для заполнения")]
        [Display(Name = "Почта")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле пароля является обязательным для заполнения")]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите пароль повторно")]
        [Display(Name = "Потверждение пароля")]
        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}

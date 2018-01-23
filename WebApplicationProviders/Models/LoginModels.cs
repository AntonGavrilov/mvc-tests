using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationProviders.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name ="Логин")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Пароль")]
        public string Password { get; set; }
        [Display(Name ="Запомнить")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "Логин")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Электронная почта")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают.")]
        public string ConfirmPassword { get; set; }
    }
}
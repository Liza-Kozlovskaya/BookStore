using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Models
{
    public class User
    {
        //[HiddenInput(DisplayValue = false)]
        //[Display(Name = "ID")]
        public int Id { get; set; }

        //[Display(Name = "Email")]
        //[Required(ErrorMessage = "Пожалуйста, введите Email пользователя")]
        public string Email { get; set; }

        //[Display(Name = "Пароль")]
        //[Required(ErrorMessage = "Пожалуйста, введите пароль пользователя")]
        public string Password { get; set; }

        //[Display(Name = "Возраст пользователя")]
        //[Required(ErrorMessage = "Пожалуйста, введите возраст пользователя")]
        public int Age { get; set; }

        //[Display(Name = "Роль ID")]
        //[Required]
        //[Range(0, 1)]
        public int RoleId { get; set; }

        //[Display(Name = "Роль")]
        //[Required(ErrorMessage = "Пожалуйста, введите поль пользователя")]
        public Role Role { get; set; }
    }

    public class Role
    {
        //[HiddenInput(DisplayValue = false)]
        //[Display(Name = "ID")]
        public int Id { get; set; }

        //[Display(Name = "Email")]
        //[Required(ErrorMessage = "Пожалуйста, введите название роли")]
        public string Name { get; set; }
    }
}
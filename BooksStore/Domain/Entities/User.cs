using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Domain.Entities
{
    public class User
    {
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage ="Пожалуйста, введите email пользователя")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage ="Пожалуйста, укажите пароль пользователя")]
        public string Password { get; set; }

        //возраст может быть от 10 до 80
        [Display(Name = "Age")]
        [Required]
        [Range(10, 80, ErrorMessage = "Пожалуйста, укажите возраст пользователя")]
        public int Age { get; set; }

        //ограничение
        //меньше 0 и больше 1 не может быть
        [Display(Name = "RoleID")]
        [Required]
        [Range(1, 3, ErrorMessage = "Пожалуйста, укажите роль пользователя")]
        public int RoleId { get; set; }

        [Display(Name = "UserName")]
        [Required(ErrorMessage = "Пожалуйста, введите имя пользователя")]
        public string UserName { get; set; }
    }

    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
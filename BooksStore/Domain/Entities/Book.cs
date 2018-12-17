using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Domain.Entities
{
    //Содержимое книги
    public class Book
    {
        [HiddenInput(DisplayValue=false)]
        [Display(Name = "ID")]
        public int BookId { get; set; }

        [Display(Name="Название")]
        [Required(ErrorMessage ="Пожалуйста, введите название книги")]
        //ограничение, если пользователь не ввёл ни одного символа
        public string Name { get; set; }

        [Display(Name = "Автор")]
        [Required(ErrorMessage = "Пожалуйста, введите автора книги")]
        //ограничение, если пользователь не ввёл ни одного символа
        public string Author { get; set; }

        [DataType(DataType.MultilineText)] //указывает, каким должно быть представлено значение и как его редактировать
        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Пожалуйста, введите описание книги")]
        //ограничение, если пользователь не ввёл ни одного символа
        public string Description { get; set; }

        [Display(Name = "Категория")]
        [Required(ErrorMessage = "Пожалуйста, введите жанр книги")]
        //ограничение, если пользователь не ввёл ни одного символа
        public string Genre { get; set; }

        [Display(Name = "Цена")]
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Пожалуйста, введитеположительное значение цены")] 
        //ограничение на ввод чисел меньше 0
        public decimal Price { get; set; }
    }
}

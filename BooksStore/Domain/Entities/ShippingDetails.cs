using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ShippingDetails
    {

        //Отображение оформления заказа
        [Required(ErrorMessage ="Укажите ваше имя")]
        public string Name { get; set; } //фио

        [Required(ErrorMessage = "Укажите адрес доставки")]
        [Display(Name ="Адрес доставки")] //адрес получателя
        public string Line1 { get; set; }

        [Required(ErrorMessage = "Укажите ваш город")]
        [Display(Name = "Город")]  //город
        public string City { get; set; }

        [Required(ErrorMessage = "Укажите вашу страну")]
        [Display(Name = "Страна")]   //страна
        public string Country { get; set; }

        public bool GiftWrap{ get; set; } //подарочная упаковка


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class PagingInfo
    {
        public int TotalItems { get; set; }  //общее количество книг
        public int ItemsPerPage { get; set; } //количество книг на странице
        public int CurrentPage { get; set; }  //номер текущей страницы
        public int TotalPages   //количество страниц
        {
            get
            {
                //количество страниц в каталоге
                return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
            }
        }
    }
}
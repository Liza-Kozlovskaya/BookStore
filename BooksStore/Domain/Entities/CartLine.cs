using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CartLine
    {
        //Корзина состоит из книг и их количества
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}

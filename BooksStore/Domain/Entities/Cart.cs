using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class Cart
    {
        //корзина
        private List<CartLine> lineCollection = new List<CartLine>();

        public IEnumerable<CartLine> Lines
        { get
            {
                return lineCollection; //содержимое корзины
            }
        } 

        public void AddItem(Book book, int quantity)//метод добавления товара в корзину
        {
            CartLine line = lineCollection
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();

            if(line == null)
            {
                lineCollection.Add(new CartLine { Book = book, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Book book) //метод удаления из корзины
        {
            lineCollection.RemoveAll(l => l.Book.BookId == book.BookId);
        }


        public decimal ComputeTotalValue()//метод вычисления общей стоимости
        {
            //умножается количество книг на цену 
            return lineCollection.Sum(e => e.Book.Price * e.Quantity);
        }

        public void Clear() //метод очистки корзины
        {
            lineCollection.Clear();
        }
    }
}

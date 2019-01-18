using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    //Представляет хранилище. Реализует интерфес IBookRepository и использует EFDbContext
    //для извлечения данных из бд

    public class EFBookRepository : IBookRepository
    {
        EFDbContext context = new EFDbContext();
        public IEnumerable<Book> Books
        {
            get
            {
                return context.Books;
            }
        }

        public void SaveBook(Book book) 
        {
            if(book.BookId == 0)//добавляет товар, если значение индекса равно 0
            {
                context.Books.Add(book);
            }
            else //изменение бд
            {
                Book dbEntry = context.Books.Find(book.BookId);
                if(dbEntry != null)
                {
                    dbEntry.Name = book.Name;
                    dbEntry.Author = book.Author;
                    dbEntry.Description = book.Description;
                    dbEntry.Genre = book.Genre;
                    dbEntry.Price = book.Price;
                    dbEntry.ImageData = book.ImageData;
                    dbEntry.ImageMimeType = book.ImageMimeType;
                }
            }
            context.SaveChanges();
        }

        public Book DeleteBook(int bookId)
        {
            Book dbEntry = context.Books.Find(bookId);
            if (dbEntry != null)
            {
                context.Books.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}

﻿using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    //Представляет хранилище. Реализует интерфес IBookRepository и использует EFDbContext
    //для извлечения данных из бд с помощью Entity Framework

    public class EFBookRepository : IBookRepository
    {
        EFDbContext context = new EFDbContext();
        public IEnumerable<Book> Books
        {
            get { return context.Books; }
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
                }
                context.SaveChanges();
            }
        }
    }
}

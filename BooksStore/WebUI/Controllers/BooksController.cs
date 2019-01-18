using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    //информация о книгах в хранилище
    public class BooksController : Controller
    {
        private IBookRepository repository;
        public int pageSize = 4;

        public BooksController(IBookRepository repo)
        {
            repository = repo;
        }

        public FileContentResult GetImage(int bookId)
        {
            Book book = repository.Books.FirstOrDefault(b => b.BookId == bookId);

            if (book != null)
            {
                return File(book.ImageData, book.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

        public ViewResult List(string genre, int page = 1) //лист товаров
        {
            BooksListViewModel model = new BooksListViewModel
            {
                Books = repository.Books
                .Where(b => genre == null || b.Genre == genre)
                .OrderBy(book => book.BookId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page, //текущая страница
                    ItemsPerPage = pageSize, //количество книг на странице
                    TotalItems = genre == null ?  //всего товаров в каталоге
                         repository.Books.Count() : 
                         repository.Books.Where(book => book.Genre == genre).Count()
                },
                CurrentGenre = genre
            };

            return View(model);
        }
    }
}
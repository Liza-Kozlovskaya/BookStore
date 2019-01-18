using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    //контроллер действий администратора
    public class AdminController : Controller
    {
        IBookRepository repository;

        public AdminController(IBookRepository repo)
        {
            repository = repo;
        }

        //выводит полный список всех книг в бд
        public ViewResult Index()
        {
            return View(repository.Books);
        }

        public ViewResult Edit(int bookId)
        {
            Book book = repository.Books.FirstOrDefault(b => b.BookId == bookId);
            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book book, HttpPostedFileBase image = null)
        {
            if(ModelState.IsValid) //если было заполнено не правильно, то просим администратора отредактировать ещё раз
            {
                if(image!=null)
                {
                book.ImageMimeType = image.ContentType;
                book.ImageData = new byte[image.ContentLength];
                image.InputStream.Read(book.ImageData, 0, image.ContentLength);
                }
                repository.SaveBook(book);
                TempData["message"] = string.Format("Изменение информации о книге \"{0}\" сохранены", book.Name);
                //вывод сообщения на страницу
                return RedirectToAction("Index");
            }
            else
            {
                return View(book);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Book());
        }

        [HttpPost]
        public ActionResult Delete(int bookId)
        {
            Book deletedBook = repository.DeleteBook(bookId);
            if (deletedBook != null)
            {
                TempData["message"] = string.Format("Книга \"{0}\" была удалена",
                    deletedBook.Name);
            }
            return RedirectToAction("Index");
        }
    }
}
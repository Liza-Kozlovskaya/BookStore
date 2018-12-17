using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
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

        public ViewResult Index()
        {
            return View(repository.Books);
        }

        public ViewResult Edit(int bookId) //редактирование книги
        {
            Book book = repository.Books.FirstOrDefault(b => b.BookId == bookId);

            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if(ModelState.IsValid) //если было заполнено не правильно, то просим администратора отредактировать ещё раз
            {
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
    }
}
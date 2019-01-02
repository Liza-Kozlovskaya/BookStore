using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class UsersController : Controller
    {
        private IUserRepository repository;
        public UsersController(IUserRepository repo)
        {
            repository = repo;
        }

        //возвращает полный список юзеров в бд
        public ViewResult Index()
        {
            return View(repository.Users);
        }

        //редактирование пользователей/назначение модераторов
        public ViewResult EditUser(int Id)
        {
            User user = repository.Users.FirstOrDefault(u => u.Id == Id);
            return View(user);
        }


        [HttpPost]
        public ActionResult EditUser(User user)
        {
            if(ModelState.IsValid)
            {
                repository.SaveUser(user); //если редактирование было не корректным, то просим администратора изменить ещё раз
                TempData["message"] = string.Format("Изменение информации о пользователе \"{0}\"сохранены", user.Email);
                //вывод сообщения на страницу со всеми книгами
                return RedirectToAction("Index");
            }
            else
            {
                return View(user);
            }
        }
    }
}
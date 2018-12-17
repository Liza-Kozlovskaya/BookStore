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

        public ViewResult Index()
        {
            return View(repository.Users);
        }

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
                repository.SaveUser(user);
                TempData["message"] = string.Format("Изменение информации о пользователе \"{0}\"сохранены", user.Email);
                return RedirectToAction("Index");
            }
            else
            {
                return View(user);
            }
        }
    }
}
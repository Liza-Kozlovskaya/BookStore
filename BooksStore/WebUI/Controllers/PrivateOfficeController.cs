using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class PrivateOfficeController : Controller
    {
        //private IUserRepository repository;
        //public PrivateOfficeController(IUserRepository repo)
        //{
        //    repository = repo;
        //}

        public ActionResult PrivateOffice(/*User user*/)
        {
            //User user = repository.Users.FirstOrDefault(u => u.Id == Id);
            return View(/*user*/);
        }
    }
}
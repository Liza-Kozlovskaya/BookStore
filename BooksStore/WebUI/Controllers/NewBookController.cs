using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class NewBookController : Controller
    {
        public ActionResult NewBook()
        {
            return View();
        }
    }
}
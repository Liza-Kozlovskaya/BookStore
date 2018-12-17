using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class HomesController : Controller
    {
        //контроллер начальной страницы с информацией
        public ActionResult Home()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            string result = "�� �� ������������";
            if (User.Identity.IsAuthenticated)
            {
                result = "��� �����: " + User.Identity.Name;
            }
            return result;

        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Yoyr application description page";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page";
            return View();
        }


        //���������� ��������� �������� � �����������
        public ActionResult Home()
        {
            return View();
        }
    }
}
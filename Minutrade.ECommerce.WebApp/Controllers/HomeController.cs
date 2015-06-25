using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Minutrade.ECommerce.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Minutrate ECommerce Application";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Paulo Rocio";

            return View();
        }
    }
}
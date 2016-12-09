using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Why Information Systems?";

            return View();

        }


        public ActionResult Contact()
        {
            //ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Contact(FormCollection collection)
        {
            // This will clear whatever form items have been populated
            ModelState.Clear();

            return View();
        }

        public ActionResult Calendar()
        {
            //ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
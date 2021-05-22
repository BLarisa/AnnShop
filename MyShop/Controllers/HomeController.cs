using MyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            annshopDBEntities db = new annshopDBEntities();

            List<TestTable> table = db.TestTable.ToList();

            string response = "";

            foreach(TestTable t in table)
            {
                response += " - " + t.value + "\n";
            }

            ViewBag.Message = "TestTable Values: \n" + response;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
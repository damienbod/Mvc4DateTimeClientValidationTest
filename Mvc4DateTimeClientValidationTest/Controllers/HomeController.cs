using System;
using System.Web.Mvc;
using Mvc4DateTimeClientValidationTest.Models;

namespace Mvc4DateTimeClientValidationTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var t = new TestModel
                {
                    Date1 = DateTime.Now,
                    Date2 = DateTime.Now,
                    NoValidationDate1 = DateTime.Now,
                    NoValidationDate2 = DateTime.Now
                };
            return View(t);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagicEnglish.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Magic English provides a range of English learning services. It gives instant access to private lessons with hundreds of patient and professional native English speaking tutors from Australia";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact page.";

            return View();
        }

        public ActionResult Course()
        {
            ViewBag.Message = "Course page";

            return View();
        }

        public ActionResult OnlineTest()
        {
            ViewBag.Message = "Online Test page";

            return View();
        }

        public ActionResult Resource()
        {
            ViewBag.Message = "Resource page";

            return View();
        }
    }
}
using MagicEnglish.Models;
using MagicEnglish.Utils;
using Microsoft.Owin.Security.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using System.IO;

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

        public ActionResult NeedRegister()
        {
            ViewBag.Message = "Need Register";

            return View();
        }




        public ActionResult Send_Email()
        {
            var culture = new System.Globalization.CultureInfo("en");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            return View(new SendEmailViewModel());
        }

        [HttpPost]

        public ActionResult Send_Email(SendEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    String toEmail = model.ToEmail;
                    String subject = model.Subject;
                    String contents = model.Contents;

                    var attachment = Request.Files["attachment"];

                    if (attachment.ContentLength > 0)
                    {
                        String path = Path.Combine(Server.MapPath("~/Content/Attachment/"), attachment.FileName); //?????
                        attachment.SaveAs(path);

                        EmailSender es = new EmailSender();
                        es.SendWithAttachment(toEmail, subject, contents, path, attachment.FileName);
                    }
                    else
                    {
                        EmailSender es = new EmailSender();
                        es.Send(toEmail, subject, contents);
                    }

                    ViewBag.Result = "Email has been send.";

                    ModelState.Clear();

                    return View(new SendEmailViewModel());
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

    }
}
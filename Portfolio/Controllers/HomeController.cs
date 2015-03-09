using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpGet]
        public ActionResult ContactMe()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ContactMe(Models.ContactForm contactForm)
        {
            try
            {
                //set the date created
                contactForm.CreationDate = DateTime.Now;

                Models.ContactFormEntities db = new Models.ContactFormEntities();
                db.ContactForms.Add(contactForm);
                db.SaveChanges();
            }
            catch (Exception exception)
            {
                ViewBag.Error = exception.Message;
                return View("Error");
            }

            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage("robot@apelekh.com", "andrii.pelekh@gmail.com");
            message.Subject = "You got a message!";
            message.Body = string.Format("{0} at {1} wrote you a message below: \n {2}", contactForm.Name, contactForm.EmailAddress, contactForm.TextMessage);
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("mail.dustinkraft.com");
            client.Port = 587;
            client.Credentials = new System.Net.NetworkCredential("postmaster@dustinkraft.com", "techIsFun1");

            client.Send(message);

            return RedirectToAction("ThankYou", "Home");
        }

        public ActionResult ThankYou()
        {
            return View();
        }
    }
}
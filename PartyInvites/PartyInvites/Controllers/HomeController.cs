using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using PartyInvites.Models;
using System.Net;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afernoon";
            return View();
        }

        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                //TODO: Email response to the party organizer
                try
                {
                    MailAddress from = new MailAddress("krupnij@tut.by", "Party organizer site");
                    MailAddress to = new MailAddress("aleksandr.stepanov@gmail.com");
                    MailMessage mail = new MailMessage(from, to);
                    mail.Subject = "New Year's Eve party participation!";
                    mail.Body = "<h2>" + guestResponse.Name + ": " + guestResponse.Email + "</h2><br>" + guestResponse.WillAttend;
                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 25);
                    smtp.EnableSsl = true;
                    //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    //smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("krupnij@tut.by", "ZhdAn0v1chi_645");
                    smtp.Send(mail);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Error of sending message to the party organizer", MessageBoxButtons.OK);
                }
                return View("Thanks", guestResponse);
            }
            else
            {
                //there is a validation error
                return View();
            }
        }
    }
}
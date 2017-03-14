using System;
using System.Web.Mvc;
using ModelValidation.Models;

namespace ModelValidation.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult MakeBooking()
        {
            return View(new Appointment { Date = DateTime.Now });
        }

        [HttpPost]
        public ViewResult MakeBooking(Appointment appt)
        {
            //if (string.IsNullOrEmpty(appt.ClientName))
            //{
            //    ModelState.AddModelError("ClientName", "Please enter your name");
            //}
            //if (ModelState.IsValidField("Date") && DateTime.Now > appt.Date) 
            //{
            //    ModelState.AddModelError("Date", "Please enter a date in the future");
            //}
            //if (!appt.TermsAccepted)
            //{
            //    ModelState.AddModelError("TermsAccepted", "You must accept the terms");
            //}

            //if (ModelState.IsValidField("ClientName")  && ModelState.IsValidField("Date") 
            //    && appt.ClientName == "Joe" && appt.Date.DayOfWeek == DayOfWeek.Monday)
            //{
            //    ModelState.AddModelError("", "Joe cannot book appointments on Mondays");
            //}

            if (ModelState.IsValid)
            {
                // В рельном проекте здесь находились бы операторы для сохранения нового объекта Appointment в хранилище
                return View("Completed", appt);
            }
            else
            {
                return View();
            }
        }
    }
}
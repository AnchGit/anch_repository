using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllersAndActions.Controllers
{
    public class ExampleController : Controller
    {
        // GET: Example
        public ViewResult Index()
        {
            //DateTime date = DateTime.Now;
            //return View(date);
            ViewBag.Message = "Hello";
            ViewBag.Date = DateTime.Now;
            return View();
        }

        public RedirectToRouteResult Redirect()
        {
            //return RedirectPermanent("/Example/Index");
            return RedirectToRoute(new { controller = "Example", action = "Index", ID = "MyID" });
        }

        public HttpStatusCodeResult StatusCode()
        {
            // URL не может быть обслужен
            //return new HttpStatusCodeResult(404, "URL cannot be serviced");
            //return HttpNotFound();
            return new HttpUnauthorizedResult();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControllersAndActions.Infrastructure;

namespace ControllersAndActions.Controllers
{
    public class DerivedController : Controller
    {
        // GET: Derived
        public ActionResult Index()
        {
            ViewBag.Message = "Hello from the DerivedController Index method";
            return View("MyView");
        }

        public ActionResult ProduceOutput()
        {
            //if (Server.MachineName == "computer")
            //{
            //    //Response.Redirect("/Basic/Index");
            //    return new CustomRedirectResult { Url = "/Basic/Index" };
            //}
            //else
            //{
            //    //Response.Write("Controller: Derived, Action: ProduceOutput");
            //    return null;
            //}
            return Redirect("/Basic/Idex");
        }

        //public ActionResult RenameProduct()
        //{
        //    // Получить доступ к разнообразным свойствам из объектов контекста
        //    string userName = User.Identity.Name;
        //    string serverName = Server.MachineName;
        //    string clientIP = Request.UserHostAddress;
        //    DateTime dateStamp = HttpContext.Timestamp;
        //    AuditRequest(userName, serverName, clientIP, dateStamp, "Renaming product");

        //    // Извлечь отправленные данные из Request.Form
        //    string oldProductName = Request.Form["OldName"];
        //    string newProductName = Request.Form["NewName"];
        //    bool result = AttemptProductRename(oldProductName, newProductName);
        //    ViewData["RenameResult"] = result;
        //    return View("ProductRenamed");
        //}


    }
}
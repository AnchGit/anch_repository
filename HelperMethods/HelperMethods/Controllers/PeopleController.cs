using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using HelperMethods.Models;

namespace HelperMethods.Controllers
{
    public class PeopleController : Controller
    {
        private Person[] personData =
        {
            new Person { FirstName = "Dean", LastName = "Ambrose", Role = Role.Admin },
            new Person { FirstName = "Seth", LastName = "Rollins", Role = Role.User },
            new Person { FirstName = "John", LastName = "Cena", Role = Role.User },
            new Person { FirstName = "Roman", LastName = "Reigns", Role = Role.Guest }
        };

        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult GetPeople()
        //{
        //    return View(personData);
        //}

        //[HttpPost]
        //public ActionResult GetPeople(string selectedRole)
        //{
        //    if (selectedRole == null || selectedRole == "All")
        //    {
        //        return View(personData);
        //    }
        //    else
        //    {
        //        Role selected = (Role)Enum.Parse(typeof(Role), selectedRole);
        //        return View(personData.Where(p => p.Role == selected));
        //    }
        //}

        //public PartialViewResult GetPeopleData(string selectedRole = "All")
        //{
        //    IEnumerable<Person> data = personData;
        //    if (selectedRole != "All")
        //    {
        //        Role selected = (Role)Enum.Parse(typeof(Role), selectedRole);
        //        data = personData.Where(p => p.Role == selected);
        //    }
        //    return PartialView(data);
        //}

        //private IEnumerable<Person> GetData(string selectedRole)
        //{
        //    IEnumerable<Person> data = personData;
        //    if (selectedRole != "All")
        //    {
        //        Role selected = (Role)Enum.Parse(typeof(Role), selectedRole);
        //        data = personData.Where(p => p.Role == selected);
        //    }
        //    return data;
        //}

        //public JsonResult GetPeopleDataJson(string selectedRole = "All")
        //{
        //    //IEnumerable<Person> data = GetData(selectedRole);
        //    var data = GetData(selectedRole).Select(p => new
        //    {
        //        FirstName = p.FirstName,
        //        LastName = p.LastName,
        //        Role = Enum.GetName(typeof(Role), p.Role)
        //    });
        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}

        //public PartialViewResult GetPeopleData(string selectedRole = "All")
        //{
        //    return PartialView(GetData(selectedRole));
        //}

        public ActionResult GetPeopleData(string selectedRole = "All")
        {
            IEnumerable<Person> data = personData;
            if (selectedRole != "All")
            {
                Role selected = (Role)Enum.Parse(typeof(Role), selectedRole);
                data = personData.Where(p => p.Role == selected);
            }
            if (Request.IsAjaxRequest())
            {
                var formattedData = data.Select(p => new
                {
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Role = Enum.GetName(typeof(Role), p.Role)
                });
                return Json(formattedData, JsonRequestBehavior.AllowGet);
            } else
            {
                return PartialView(data);
            }
        }

        public ActionResult GetPeople(string selectedRole = "All")
        {
            return View((object)selectedRole);
        }
    }
}
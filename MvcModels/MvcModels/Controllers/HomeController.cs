using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcModels.Models;

namespace MvcModels.Controllers
{
    public class HomeController : Controller
    {
        private Person[] personData =
{
            new Person { PersonId = 1, FirstName = "Dean", LastName = "Ambrose", Role = Role.Admin },
            new Person { PersonId = 2, FirstName = "Seth", LastName = "Rollins", Role = Role.User },
            new Person { PersonId = 3, FirstName = "John", LastName = "Cena", Role = Role.User },
            new Person { PersonId = 4, FirstName = "Roman", LastName = "Reigns", Role = Role.Guest }
        };

        public ActionResult Index(int? id = 1)
        {
            Person dataItem = personData.Where(p => p.PersonId == id).First();
            return View(dataItem);
        }

        public ActionResult CreatePerson()
        {
            return View(new Person());
        }

        [HttpPost]
        public ActionResult CreatePerson(Person model)
        {
            return View("Index", model);
        }

        public ActionResult DisplaySummary([Bind(Prefix = "HomeAddress", Exclude = "Country")]AddressSummary summary)
        {
            return View(summary);
        }

        public ActionResult Names(string[] names)
        {
            names = names ?? new string[0];
            return View(names);
        }

        public ActionResult NamesList(IList<string> names)
        {
            names = names ?? new List<string>();
            return View(names);
        }

        //public ActionResult Address(IList<AddressSummary> addresses)
        //{
        //    addresses = addresses ?? new List<AddressSummary>();
        //    return View(addresses);
        //}

        //public ActionResult Address(FormCollection formData)
        //{
        //    IList<AddressSummary> addresses = new List<AddressSummary>();
        //    //try
        //    //{
        //    //    UpdateModel(addresses, formData);
        //    //}
        //    //catch (InvalidOperationException ex)
        //    //{
        //    //    // Предоставить обратную связь пользователю
        //    //}
        //    if (TryUpdateModel(addresses, formData))
        //    {
        //        // Продолжить обработку обычным способом
        //    }
        //    else
        //    {
        //        // Предоставить обратную связь пользователю
        //    }
        //    return View(addresses);
        //}

        public ActionResult Address()
        {
            IList<AddressSummary> addresses = new List<AddressSummary>();
            UpdateModel(addresses);
            return View(addresses);
        }
    }
}
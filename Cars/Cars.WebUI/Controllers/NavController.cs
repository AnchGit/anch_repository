using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cars.Domain.Abstract;

namespace Cars.WebUI.Controllers
{
    public class NavController : Controller
    {
        private ICarRepository carRepo;

        public NavController(IMarkRepository markRepository, ICarRepository carRepository)
        {
            carRepo = carRepository;
        }
        public PartialViewResult Menu(string selected = null)
        {
            ViewBag.SelectedMark = selected;
            IEnumerable<string> marks = carRepo.Cars
                                .Select(m => m.Mark.Name)
                                .Distinct()
                                .OrderBy(m => m);
            return PartialView(marks);
        }
    }
}
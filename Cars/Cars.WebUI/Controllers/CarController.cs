using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cars.Domain.Abstract;
using Cars.Domain.Entities;
using System.Collections;
using Cars.WebUI.Models;

namespace Cars.WebUI.Controllers
{
    public class CarController : Controller
    {
        private ICarRepository carRepo;
        private IMarkRepository markRepo;
        private ShowRoom model;

        public CarController(ICarRepository carRepository, IMarkRepository markRepository)
        {
            this.carRepo = carRepository;
            this.markRepo = markRepository;
        }

        public ViewResult Index()
        {
            model = new ShowRoom { Cars = carRepo.Cars, CurrentMark = null };
            return View(model);
        }

        public ViewResult List(string selected)
        {
            Mark mark = markRepo.Marks.Where(m => m.Name == selected).FirstOrDefault();
            ShowRoom model = new ShowRoom
            {
                Cars = carRepo.Cars
                       .Where(c => selected == null || c.MarkID == mark.MarkID)
                       .OrderBy(c => c.Mark.Name),
                CurrentMark = selected
            };
            return View(model);
        }
    }
}
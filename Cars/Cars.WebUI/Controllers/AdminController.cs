using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cars.Domain.Entities;
using Cars.Domain.Abstract;
using Cars.Domain.Concrete;
using Cars.WebUI.Models;

namespace Cars.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private ICarRepository carRepo;
        private IMarkRepository markRepo;

        public AdminController(ICarRepository carRepository, IMarkRepository markRepository)
        {
            this.carRepo = carRepository;
            this.markRepo = markRepository;
        }
        public ActionResult AdminList()
        {
            ShowRoom model = new ShowRoom { Cars = carRepo.Cars, Marks = markRepo.Marks };
            return View(model);
        }

        public ViewResult Edit(int carId)
        {
            Car car = carRepo.Cars
                .FirstOrDefault(c => c.CarID == carId);
            return View(car);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cars.Domain.Abstract;
using Cars.Domain.Entities;
using System.Collections;

namespace Cars.WebUI.Controllers
{
    public class CarController : Controller
    {
        private ICarRepository carRepo;
        private IMarkRepository markRepo;

        public CarController(ICarRepository carRepository, IMarkRepository markRepository)
        {
            this.carRepo = carRepository;
            this.markRepo = markRepository;
        }
        public ViewResult List()
        {
            return View(carRepo.Cars);
        }
    }
}
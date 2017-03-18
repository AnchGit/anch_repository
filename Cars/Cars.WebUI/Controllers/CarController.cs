using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cars.Domain.Abstract;
using Cars.Domain.Entities;

namespace Cars.WebUI.Controllers
{
    public class CarController : Controller
    {
        private ICarRepository repository;

        public CarController(ICarRepository carRepository)
        {
            this.repository = carRepository;
        }
        public ViewResult List()
        {
            return View(repository.Cars);
        }
    }
}
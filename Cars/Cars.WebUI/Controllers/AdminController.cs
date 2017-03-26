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
        private ShowRoom model;
        private SelectList marks;

        public AdminController(ICarRepository carRepository, IMarkRepository markRepository)
        {
            carRepo = carRepository;
            markRepo = markRepository;
            marks = new SelectList(markRepo.Marks, "MarkID", "Name");
        }
        public ActionResult AdminList()
        {
            model = new ShowRoom { Cars = carRepo.Cars, CurrentMark = null };
            return View(model);
        }

        public ViewResult Edit(int carId)
        {
            Car car = carRepo.Cars
                        .FirstOrDefault(c => c.CarID == carId);
            ViewBag.Marks = marks;
            return View(car);
        }

        [HttpPost]
        public ActionResult Edit(Car car)
        {
            ViewBag.Marks = marks;
            if (ModelState.IsValid)
            {
                carRepo.SaveCar(car);
                return RedirectToAction("AdminList");
            }
            else
            {
                return View(car);
            }
        }

        public ViewResult CreateCar()
        {
            ViewBag.Marks = marks;
            return View("Edit", new Car());
        }

        [HttpPost]
        public ActionResult DeleteCar(int carID)
        {
            Car deletedCar =  carRepo.DeleteCar(carID);
            if (deletedCar != null)
            {
                TempData["message"] = string.Format("MarkID: {0}, Model: {1} - was deleted", deletedCar.MarkID, deletedCar.Model);
            }
            return RedirectToAction("AdminList");
        }
    }
}
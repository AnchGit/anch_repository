using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cars.Domain.Abstract;
using Cars.Domain.Entities;
using Cars.WebUI.Models;
using Cars.Domain.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Cars.WebUI.Controllers
{
    public class CarController : Controller
    {
        private ICarRepository carRepo;
        private IMarkRepository markRepo;
        private IOrderRepository orderRepo;
        private ShowRoom model;

        public CarController(ICarRepository carRepository, IMarkRepository markRepository, IOrderRepository orderRepository)
        {
            this.carRepo = carRepository;
            this.markRepo = markRepository;
            this.orderRepo = orderRepository;
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
                //Cars = carRepo.Cars
                //       .Where(c => selected == null || c.MarkID == mark.MarkID)
                //       .OrderBy(c => c.Mark.Name)
                //       .GroupBy(c => new { c.MarkID, c.Model })
                //       .Select(c => c.FirstOrDefault()),
                //CurrentMark = selected
            };
            return View(model);
        }

        public ActionResult Order(int carId)
        {
            Car car = carRepo.Cars
                .FirstOrDefault(c => c.CarID == carId);
            UserManager userManager = HttpContext.GetOwinContext().GetUserManager<UserManager>();
            User user = userManager.FindByEmail(User.Identity.Name);
            if (user != null)
            {
                ViewBag.User = user;
                ViewBag.Car = car;
                OrderModel orderModel = new OrderModel { Order = new Order { }, Car = car, User = user };
                return View(orderModel);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult Order(OrderModel orderModel)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                orderRepo.SaveOrder(orderModel.Order, orderModel.Car, orderModel.User);
                return RedirectToAction("List");
            }
            else
            {
                return View("Index");
            }
        }
    }
}
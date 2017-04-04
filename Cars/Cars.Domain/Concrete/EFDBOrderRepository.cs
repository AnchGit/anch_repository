using Cars.Domain.Entities;
using Cars.Domain.Abstract;
using System.Collections.Generic;
using Cars.Domain.Identity;
using System;

namespace Cars.Domain.Concrete
{
    public class EFDBOrderRepository : IOrderRepository
    {
        private EFDBContext context = new EFDBContext();

        public IEnumerable<Order> Orders
        {
            get { return context.Orders; }
        }

        public void SaveOrder(Order order, Car car, User user)
        {
            if (order.OrderID == 0)
            {
                order.CarID = car.CarID;
                order.Car = car;
                order.UserID = user.Id;
                order.OrderDate = DateTime.Now.Date;
                context.Orders.Add(order);
            }
            else
            {
                Order dbEntry = context.Orders.Find(order.OrderID);
                if (dbEntry != null)
                {
                    dbEntry.CarID = order.CarID;
                    dbEntry.Car = order.Car;
                    dbEntry.OrderDate = order.OrderDate;
                    dbEntry.UserID = order.UserID;
                }
            }
            context.SaveChanges();
        }
    }
}

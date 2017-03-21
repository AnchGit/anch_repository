using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Cars.Domain.Entities;
using Cars.Domain.Abstract;

namespace Cars.Domain.Concrete
{
    public class EFDbCarRepository : ICarRepository
    {
        private EFDBContext context = new EFDBContext();

        public IEnumerable<Car> Cars
        {
            get { return context.Cars.Include(c => c.Mark); }
        }

        public void SaveCar(Car car)
        {
            if (car.CarID == 0)
            {
                context.Cars.Add(car);
            }
            else
            {
                Car dbEntry = context.Cars.Find(car.CarID);
                if (dbEntry != null)
                {
                    dbEntry.MarkID = car.MarkID;
                    dbEntry.Mark = car.Mark;
                    dbEntry.Model = car.Model;
                    dbEntry.Color = car.Color;
                    dbEntry.Engine = car.Engine;
                    dbEntry.IssueDate = car.IssueDate;
                    dbEntry.Price = car.Price;
                } 
            }
            context.SaveChanges();
        }

        public Car DeleteCar(int carID)
        {
            Car dbEntry = context.Cars.Find(carID);
            if (dbEntry != null)
            {
                context.Cars.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
   }
}

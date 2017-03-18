using System.Collections.Generic;
using Cars.Domain.Entities;
using Cars.Domain.Abstract;

namespace Cars.Domain.Concrete
{
    public class EFDbCarRepository : ICarRepository
    {
        private EFDBContext context = new EFDBContext();

        public IEnumerable<Car> Cars
        {
            get { return context.Cars; }
        }
    }
}

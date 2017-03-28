using Cars.Domain.Entities;
using Cars.Domain.Abstract;
using System.Collections.Generic;

namespace Cars.Domain.Concrete
{
    public class EFDBOrderRepository : IOrderRepository
    {
        private EFDBContext context = new EFDBContext();

        public IEnumerable<Order> Orders
        {
            get { return context.Orders; }
        }
    }
}

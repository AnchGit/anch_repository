using System.Collections.Generic;
using Cars.Domain.Entities;
using Cars.Domain.Identity;

namespace Cars.Domain.Abstract
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Orders { get; }

        void SaveOrder(Order order, Car car, User user);
    }
}

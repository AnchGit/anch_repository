using System.Collections.Generic;
using Cars.Domain.Entities;

namespace Cars.Domain.Abstract
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Orders { get; }
    }
}

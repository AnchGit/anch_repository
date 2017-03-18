using System.Collections.Generic;
using Cars.Domain.Entities;

namespace Cars.Domain.Abstract
{
    public interface ICarRepository
    {
        IEnumerable<Car> Cars { get; }
    }
}

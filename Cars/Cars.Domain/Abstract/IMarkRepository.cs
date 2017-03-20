using System.Collections.Generic;
using Cars.Domain.Entities;

namespace Cars.Domain.Abstract
{
    public interface IMarkRepository
    {
        IEnumerable<Mark> Marks { get; }
    }
}

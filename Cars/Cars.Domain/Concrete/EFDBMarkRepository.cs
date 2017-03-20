using Cars.Domain.Entities;
using Cars.Domain.Abstract;
using System.Collections.Generic;

namespace Cars.Domain.Concrete
{
    public class EFDBMarkRepository : IMarkRepository
    {
        private EFDBContext context = new EFDBContext();

        public IEnumerable<Mark> Marks
        {
            get { return context.Marks; }
        }
    }
}

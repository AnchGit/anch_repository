using Cars.Domain.Entities;
using System.Data.Entity;

namespace Cars.Domain.Concrete
{
    public class EFDBContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
    }
}

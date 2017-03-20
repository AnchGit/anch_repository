using Cars.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Cars.Domain.Concrete
{
    public class EFDBContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Mark> Marks { get; set; }
    }
}

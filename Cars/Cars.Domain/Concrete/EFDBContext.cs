using Cars.Domain.Entities;
using Cars.Domain.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Cars.Domain.Concrete
{
    public class EFDBContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Order> Orders { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
        //    modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
        //    modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        //    modelBuilder.Entity<Order>().HasRequired(o => o.Car).WithOptional();
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<IdentityUserLogin>().ToTable("AspNetUserLogins");
        //    modelBuilder.Entity<IdentityRole>().ToTable("AspNetRoles");
        //    modelBuilder.Entity<IdentityUserRole>().ToTable("AspNetUserRoles");
        //    modelBuilder.Entity<IdentityUser>().ToTable("AspNetUsers");
        //    modelBuilder.Entity<IdentityUserClaim>().ToTable("AspNetUserClaims");
        //}
    }
}

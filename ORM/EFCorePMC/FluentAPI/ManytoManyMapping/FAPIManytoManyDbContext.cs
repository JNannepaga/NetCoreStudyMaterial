using EFCorePMC.FluentAPI.ManytoManyMapping.EntityConfig;
using EFCorePMC.FluentAPI.ManytoManyMapping.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCorePMC.FluentAPI.ManytoManyMapping
{
    public class FAPIManytoManyDbContext : DbContext
    {
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=Desktop-A16AJK2\SQLExpress;
                                          Database=EFC_FAPI_Many_Many_Mapping;
                                          Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().Ignore(c => c.FullName);
            modelBuilder.ApplyConfiguration(new StudentEntityConfig());
            modelBuilder.ApplyConfiguration(new CourseEntiyConfig());
        }
    }
}

using EFCorePMC.FluentAPI.OnetoManyMapping.EntityMapper;
using EFCorePMC.FluentAPI.OnetoManyMapping.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCorePMC.FluentAPI.OnetoManyMapping
{
    public class FAPIManytoManyDbContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=Desktop-A16AJK2\SQLExpress;
                                          Database=EFC_FAPI_One_Many_Mapping;
                                          Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().Ignore(c => c.FullName);
            modelBuilder.ApplyConfiguration(new CustomerEntityConfig());
            modelBuilder.ApplyConfiguration(new OrderEntityConfig());
        }
    }
}

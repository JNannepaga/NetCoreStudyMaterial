using EFCorePMC.FluentAPI.OnetoOneMapping.EntityMapper;
using EFCorePMC.FluentAPI.OnetoOneMapping.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCorePMC.FluentAPI.OnetoOneMapping
{
    public class FAPIOnetoOneDbContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerRequisite> CustomerRequisites { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=Desktop-A16AJK2\SQLExpress;Database=EFC_FAPI_One_One_Mapping;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().Ignore(c => c.FullName);
            modelBuilder.ApplyConfiguration(new CustomerEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerRequisiteEntityConfigurations());
        }
    }
}

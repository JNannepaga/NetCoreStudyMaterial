using System;
using EFCorePMC.DataAnnotation.OnetoOneMapping.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCorePMC.DataAnnotation.OnetoOneMapping
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<RegularCustomer> RegularCustomers { get; set; }
        public virtual DbSet<GeneralCustomer> GeneralCustomers { get; set; }
        public virtual DbSet<CustomerRequisite> CustomerRequisites { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=Desktop-A16AJK2\SQLExpress;Database=EFC_DAA_One_One_Mapping;Trusted_Connection=True;");
            //base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

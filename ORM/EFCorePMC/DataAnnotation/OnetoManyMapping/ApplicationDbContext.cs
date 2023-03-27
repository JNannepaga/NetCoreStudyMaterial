using System;
using EFCorePMC.DataAnnotation.OnetoManyMapping.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCorePMC.DataAnnotation.OnetoManyMapping
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=Desktop-A16AJK2\SQLExpress;Database=EFC_DAA_One_Many_Mapping;Trusted_Connection=True;");
            //base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

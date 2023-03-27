using EFCorePMC.DataAnnotation.ManytoManyMapping.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCorePMC.DataAnnotation.ManytoManyMapping
{
    public class ManytoManyDbContext : DbContext
    {
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=Desktop-A16AJK2\SQLExpress;Database=EFC_DAA_Many_Many_Mapping;Trusted_Connection=True;");
            //base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

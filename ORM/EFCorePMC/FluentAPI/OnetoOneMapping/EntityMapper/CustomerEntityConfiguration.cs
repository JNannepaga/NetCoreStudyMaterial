using EFCorePMC.FluentAPI.OnetoOneMapping.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePMC.FluentAPI.OnetoOneMapping.EntityMapper
{
    internal class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            #region Configure Entity Mappings
            //Relational Mappings
            builder.ToTable("Customer")
                   .HasOne(c => c.CustomerRequisites)
                   .WithOne(cr => cr.Customer)
                   .HasForeignKey<CustomerRequisite>(c => c.CustomerRequisiteId);//ForignKey

            //Keys
            builder.HasKey(c => c.CustomerId); //Primary Key 
            #endregion

            #region Configure Property Mappings
            builder.Property(c => c.CustomerId)
                .HasColumnName("CustomerId")
                .HasColumnType("INT")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(c => c.FirstName)
                .HasColumnName("FirstName")
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.LastName)
                .HasColumnName("LastName")
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);

            builder.Property(c => c.Gender)
                .HasColumnName("Gender")
                .HasColumnType("INT");

            #endregion
        }
    }
}

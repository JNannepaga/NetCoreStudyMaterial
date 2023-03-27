using EFCorePMC.FluentAPI.OnetoManyMapping.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePMC.FluentAPI.OnetoManyMapping.EntityMapper
{
    internal class CustomerEntityConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            #region Entity Mapping
            //Relational Mappings
            builder.ToTable<Customer>("Customer")
                   .HasMany(c => c.Orders)
                   .WithOne(o => o.Customer)
                   .HasForeignKey(c => c.CustomerRefId)
                   .IsRequired();

            //Keys
            builder.HasKey(c => c.CustomerId);
            #endregion

            #region Property Mapping
            builder.Property(c => c.CustomerId)
                   .HasColumnName("CustomerId")
                   .HasColumnType("INT")
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn()
                   .IsRequired();

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

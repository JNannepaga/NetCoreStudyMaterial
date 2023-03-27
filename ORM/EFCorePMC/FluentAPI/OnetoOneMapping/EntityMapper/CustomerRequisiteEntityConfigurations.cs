using System;
using EFCorePMC.FluentAPI.OnetoOneMapping.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePMC.FluentAPI.OnetoOneMapping.EntityMapper
{
    internal class CustomerRequisiteEntityConfigurations : IEntityTypeConfiguration<CustomerRequisite>
    {
        public void Configure(EntityTypeBuilder<CustomerRequisite> builder)
        {
            #region Entity Mappings
            //Relational Mappings
            builder.ToTable("CustomerRequisite")
                .HasOne(cr => cr.Customer)
                .WithOne(c => c.CustomerRequisites)
                .HasForeignKey<CustomerRequisite>(c => c.CustomerRequisiteId);//ForignKey

            //Keys
            builder.HasKey(c => c.CustomerRequisiteId);//Primary Key
            #endregion

            #region Property Mappings
            builder.Property(cr => cr.CustomerRequisiteId)
                .HasColumnName("CustomerId")
                .HasColumnType("INT");

            builder.Property(cr => cr.Mobile)
                .HasColumnName("MobileNum")
                .HasColumnType("VARCHAR")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(cr => cr.IdProofType)
                .HasColumnName("IdProofType")
                .HasColumnType("INT");

            builder.Property(cr => cr.IdProof)
                .HasColumnName("IdProof")
                .HasColumnType("VARCHAR")
                .HasMaxLength(25);
            #endregion
        }
    }
}

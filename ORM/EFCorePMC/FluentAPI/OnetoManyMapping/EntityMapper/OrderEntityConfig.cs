using EFCorePMC.FluentAPI.OnetoManyMapping.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePMC.FluentAPI.OnetoManyMapping.EntityMapper
{
    internal class OrderEntityConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            #region Entity Mapping
            //Relational Mappings
            builder.ToTable<Order>("CustomerOrder")
                    .HasOne(o => o.Customer)   
                    .WithMany(c => c.Orders)
                    .HasForeignKey(c => c.CustomerRefId)
                    .IsRequired();

            //Keys
            builder.HasKey(o => o.OrderId);
            #endregion

            #region Property Mapping
            builder.Property(o => o.OrderId)
                   .HasColumnName("OrderId")
                   .HasColumnType("INT")
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn()
                   .IsRequired();

            builder.Property(o => o.TaxAmount)
                   .HasColumnName("TaxAmount")
                   .HasColumnType("MONEY");

            builder.Property(o => o.DeliveryCharge)
                   .HasColumnName("DeliveryCharge")
                   .HasColumnType("MONEY");

            #endregion
        }
    }
}

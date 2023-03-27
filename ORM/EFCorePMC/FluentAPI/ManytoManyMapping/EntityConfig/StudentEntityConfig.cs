using EFCorePMC.FluentAPI.ManytoManyMapping.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePMC.FluentAPI.ManytoManyMapping.EntityConfig
{
    internal class StudentEntityConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            #region Entity Mappings
            builder.ToTable<Student>("Student")
                .HasMany(s => s.Courses)
                .WithMany(c => c.Students)
                .UsingEntity(sc => sc.ToTable("StudentCourses"));

            builder.HasKey(s => s.StudentId);
            #endregion

            #region Property Mappings
            builder.Property(s => s.StudentId)
                .HasColumnType("INT")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(s => s.FirstName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(s => s.LastName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);
            #endregion
        }
    }
}

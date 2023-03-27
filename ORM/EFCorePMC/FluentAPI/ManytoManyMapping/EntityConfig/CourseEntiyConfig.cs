using EFCorePMC.FluentAPI.ManytoManyMapping.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePMC.FluentAPI.ManytoManyMapping.EntityConfig
{
    internal class CourseEntiyConfig : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            #region Entity Mappings
            builder.ToTable<Course>("Course")
                .HasMany(c => c.Students)
                .WithMany(s => s.Courses)
                .UsingEntity(sc => sc.ToTable("StudentCourses"));

            builder.HasKey(s => s.CourseId);
            #endregion

            #region Property Mappings
            builder.Property(c => c.CourseId)
                .HasColumnType("INT")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(c => c.CourseName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();
            #endregion
        }
    }
}

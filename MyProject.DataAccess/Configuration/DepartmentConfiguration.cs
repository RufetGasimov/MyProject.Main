using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.Entity.Entities;

namespace MyProject.DataAccess.Configuration;

internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("Departments");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(d => d.Description)
            .HasMaxLength(500);
        builder.Property(d => d.Limit)
            .IsRequired();
        builder.Property(d => d.Location)
            .HasMaxLength(200);

    }
}

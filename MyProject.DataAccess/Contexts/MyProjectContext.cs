using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Identity.Client;
using MyProject.DataAccess.Configuration;
using MyProject.Entity.Entities;

namespace MyProject.DataAccess.Contexts;

public class MyProjectContext: DbContext
{
    public DbSet<Department> MyProperty { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MyProjectDb;Trusted_Connection=True;TrustServerCertificate = true;");
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}

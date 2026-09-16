using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MyProject.Entity.Entities;

namespace MyProject.DataAccess.Contexts;

public class MyProjectContext: DbContext
{
    public DbSet<Department> MyProperty { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=JUPITER05\\MAIN;Database=MyProjectDb;Trusted_Connection=True;TrustServerCertificate = true;");
        base.OnConfiguring(optionsBuilder);
    }
}

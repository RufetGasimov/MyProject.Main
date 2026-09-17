using Microsoft.EntityFrameworkCore;
using MyProject.Business.Exceptions;
using MyProject.DataAccess.Contexts;
using MyProject.Entity.Entities;

namespace MyProject.Business.Services.Implementations;

public class DepartmentService : IDepartmentService
{
    public readonly MyProjectContext _context;
    public DepartmentService(MyProjectContext context)
    {
        _context = context;
    }

    // CREATE
    public async Task<Department> CreateAsync(Department department)
    {


        await _context.Departments.AddAsync(department);
        await _context.SaveChangesAsync();

        return department;
    }

    // READ - ALL
    public async Task<List<Department>> GetAllAsync()
    {
        return await _context.Departments
            .AsNoTracking()
            .ToListAsync();
    }

    // READ - GET BY ID
    public async Task<Department?> GetByIdAsync(int id)
    {
        return await _context.Departments
            .AsNoTracking()
            .FirstOrDefaultAsync(d => d.Id == id);
    }


    // UPDATE
    public async Task<Department?> UpdateAsync(
        int id,
        string name,
        string? description,
        int limit,
        string? location)
    {
        Department? department =
            await _context.Departments.FindAsync(id);

        if (department == null)
            throw new NotfoundException("Department not found.");

        department.Name = name;
        department.Description = description;
        department.Limit = limit;
        department.Location = location;
        department.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return department;
    }

    // DELETE
    public async Task<bool> DeleteAsync(int id)
    {
        Department? department =
            await _context.Departments.FindAsync(id);

        if (department == null)
            return false;

        _context.Departments.Remove(department);
        await _context.SaveChangesAsync();

        return true;
    }
}

using MyProject.Entity.Entities;

namespace MyProject.Business.Services.Implementations
{
    public interface IDepartmentService
    {
        Task<Department> CreateAsync(Department department);
        Task<bool> DeleteAsync(int id);
        Task<List<Department>> GetAllAsync();
        Task<Department?> GetByIdAsync(int id);
        Task<Department?> UpdateAsync(int id, string name, string? description, int limit, string? location);
    }
}
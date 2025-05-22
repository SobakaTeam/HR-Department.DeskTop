using System.Collections.Generic;
using System.Threading.Tasks;
using WpfApp2.DBModels;

namespace WpfApp2.Services
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetAllDepartmentsAsync();
        Task<Department> GetDepartmentByIdAsync(long id);
        Task<Department> CreateDepartmentAsync(Department department);
        Task<Department> UpdateDepartmentAsync(Department department);
        Task DeleteDepartmentAsync(long id);
    }
} 
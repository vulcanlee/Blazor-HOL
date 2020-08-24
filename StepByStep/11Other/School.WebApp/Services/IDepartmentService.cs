using EFCore.Models;
using System.Linq;
using System.Threading.Tasks;

namespace School.WebApp.Services
{
    public interface IDepartmentService
    {
        Task<bool> AddAsync(Department paraObject);
        Task<bool> DeleteAsync(Department paraObject);
        Task<IQueryable<Department>> GetAsync();
        Task<Department> GetAsync(int id);
        Task<bool> UpdateAsync(Department paraObject);
    }
}
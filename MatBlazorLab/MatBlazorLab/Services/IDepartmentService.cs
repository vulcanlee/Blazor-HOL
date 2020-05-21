using EFCoreModel.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MatBlazorLab.Services
{
    public interface IDepartmentService
    {
        Task<bool> AddAsync(Department paraObject);
        Task<bool> DeleteAsync(Department paraObject);
        Task<IQueryable<Department>> GetAsync();
        Task<Department> GetAsync(int id);
        Person GetAdministrator(int id);
        Task<bool> UpdateAsync(Department paraObject);
    }
}
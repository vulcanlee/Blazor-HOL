using EFCoreModel.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionLab.Services
{
    public interface ICourseService
    {
        Task<bool> AddAsync(Course paraObject);
        Task<bool> DeleteAsync(Course paraObject);
        Task<IQueryable<Course>> GetAsync();
        Task<Course> GetAsync(int id);
        Task<bool> UpdateAsync(Course paraObject);
    }
}
using EFCoreModel.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionLab.Services
{
    public interface IOnlineCourseService
    {
        Task<bool> AddAsync(OnlineCourse paraObject);
        Task<bool> DeleteAsync(OnlineCourse paraObject);
        Task<IQueryable<OnlineCourse>> GetAsync();
        Task<OnlineCourse> GetAsync(int id);
        Task<bool> UpdateAsync(OnlineCourse paraObject);
    }
}
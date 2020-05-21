using EFCoreModel.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MatBlazorLab.Services
{
    public interface IOutlineService
    {
        Task<bool> AddAsync(Outline paraObject);
        Task<bool> DeleteAsync(Outline paraObject);
        Task<IQueryable<Outline>> GetAsync();
        Task<IQueryable<Outline>> GetByHeaderIDAsync(int id);
        Task<Outline> GetAsync(int id);
        Task<bool> UpdateAsync(Outline paraObject);
    }
}
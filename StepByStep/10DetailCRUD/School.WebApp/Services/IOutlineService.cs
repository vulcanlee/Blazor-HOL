using EFCore.Models;
using System.Linq;
using System.Threading.Tasks;

namespace School.WebApp.Services
{
    public interface IOutlineService
    {
        Task<bool> AddAsync(Outline paraObject);
        Task<bool> BeforeAddCheckAsync(Outline paraObject);
        Task<bool> BeforeUpdateCheckAsync(Outline paraObject);
        Task<bool> DeleteAsync(Outline paraObject);
        Task<IQueryable<Outline>> GetAsync();
        Task<Outline> GetAsync(int id);
        Task<IQueryable<Outline>> GetByHeaderIDAsync(int id);
        Task<bool> UpdateAsync(Outline paraObject);
    }
}
using EFCoreModel.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MatBlazorLab.Services
{
    public interface IPersonService
    {
        Task<bool> AddAsync(Person paraObject);
        Task<bool> DeleteAsync(Person paraObject);
        Task<IQueryable<Person>> GetAsync();
        Task<Person> GetAsync(int id);
        Task<bool> UpdateAsync(Person paraObject);
    }
}
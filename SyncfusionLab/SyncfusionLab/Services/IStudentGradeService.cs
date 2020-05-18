using EFCoreModel.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionLab.Services
{
    public interface IStudentGradeService
    {
        Task<bool> AddAsync(StudentGrade paraObject);
        Task<bool> DeleteAsync(StudentGrade paraObject);
        Task<IQueryable<StudentGrade>> GetByHeaderIDAsync(int id);
        Task<IQueryable<StudentGrade>> GetAsync();
        Task<StudentGrade> GetAsync(int id);
        Task<bool> UpdateAsync(StudentGrade paraObject);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatBlazorLab.Services
{
    using EFCoreModel.Models;
    using Microsoft.EntityFrameworkCore;

    public class StudentGradeService : IStudentGradeService
    {
        private readonly SchoolContext context;

        public StudentGradeService(SchoolContext context)
        {
            this.context = context;
        }

        public Task<IQueryable<StudentGrade>> GetAsync()
        {
            return Task.FromResult(context.StudentGrade
                .Include(x => x.Course)
                .Include(x => x.Student)
                .AsNoTracking().AsQueryable());
        }

        public Task<IQueryable<StudentGrade>> GetByHeaderIDAsync(int headerID)
        {
            return Task.FromResult(context.StudentGrade
                .Include(x => x.Course)
                .Include(x => x.Student)
                .Where(x => x.CourseId == headerID)
                .AsNoTracking().AsQueryable());
        }

        public async Task<StudentGrade> GetAsync(int id)
        {
            StudentGrade item = await context.StudentGrade
                .FirstOrDefaultAsync(x => x.EnrollmentId == id);
            return item;
        }

        public async Task<bool> BeforeAddCheckAsync(StudentGrade paraObject)
        {
            var checkedHasExistResult = await context.StudentGrade
                .FirstOrDefaultAsync(x => x.CourseId == paraObject.CourseId
                && x.StudentId == paraObject.StudentId);
            if (checkedHasExistResult == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> AddAsync(StudentGrade paraObject)
        {
            await context.StudentGrade.AddAsync(paraObject);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> BeforeUpdateCheckAsync(StudentGrade paraObject)
        {
            var checkedDuplicateStudentResult = await context.StudentGrade
                .FirstOrDefaultAsync(x => x.CourseId == paraObject.CourseId
                && x.StudentId == paraObject.StudentId
                && x.EnrollmentId != paraObject.EnrollmentId);
            if (checkedDuplicateStudentResult == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(StudentGrade paraObject)
        {
            StudentGrade item = await context.StudentGrade
                .FirstOrDefaultAsync(x => x.EnrollmentId == paraObject.EnrollmentId);
            if (item == null)
            {
                return false;
            }
            else
            {
                #region 在這裡需要設定需要更新的紀錄欄位值
                //context.Entry(paraObject).State = EntityState.Modified;
                #endregion
                // 
                var local = context.Set<StudentGrade>()
                    .Local
                    .FirstOrDefault(entry => entry.EnrollmentId.Equals(paraObject.EnrollmentId));

                // check if local is not null 
                if (local != null)
                {
                    // detach
                    context.Entry(local).State = EntityState.Detached;
                }
                // set Modified flag in your entry
                context.Entry(paraObject).State = EntityState.Modified;

                // save 
                await context.SaveChangesAsync();
                return true;
            }

        }

        public async Task<bool> DeleteAsync(StudentGrade paraObject)
        {
            StudentGrade item = await context.StudentGrade
                .FirstOrDefaultAsync(x => x.EnrollmentId == paraObject.EnrollmentId);
            if (item == null)
            {
                return false;
            }
            else
            {
                context.StudentGrade.Remove(item);
                await context.SaveChangesAsync();
                return true;
            }
        }
    }
}

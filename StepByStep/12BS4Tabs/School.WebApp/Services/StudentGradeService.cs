using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.WebApp.Services
{
    using School.WebApp.Helpers;
    using EFCore.Models;
    using Microsoft.EntityFrameworkCore;
    using ShareBusiness.Helpers;

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
                .AsNoTracking()
                .Include(x => x.Course)
                .Include(x => x.Student)
                .AsQueryable());
        }

        public Task<IQueryable<StudentGrade>> GetByHeaderIDAsync(int id)
        {
            return Task.FromResult(context.StudentGrade
                .AsNoTracking()
                .Include(x => x.Course)
                .Include(x => x.Student)
                .Where(x => x.StudentId == id)
                .AsQueryable());
        }

        public async Task<StudentGrade> GetAsync(int id)
        {
            StudentGrade item = await context.StudentGrade
                .AsNoTracking()
                .Include(x => x.Course)
                .Include(x => x.Student)
                .FirstOrDefaultAsync(x => x.EnrollmentId == id);
            return item;
        }

        public Task<bool> BeforeAddCheckAsync(StudentGrade paraObject)
        {
            return Task.FromResult(true);
        }

        public async Task<bool> AddAsync(StudentGrade paraObject)
        {
            CleanTrackingHelper.Clean<StudentGrade>(context);
            await context.StudentGrade.AddAsync(paraObject);
            await context.SaveChangesAsync();
            CleanTrackingHelper.Clean<StudentGrade>(context);
            return true;
        }

        public Task<bool> BeforeUpdateCheckAsync(StudentGrade paraObject)
        {
            return Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(StudentGrade paraObject)
        {
            CleanTrackingHelper.Clean<StudentGrade>(context);
            StudentGrade item = await context.StudentGrade
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.EnrollmentId == paraObject.EnrollmentId);
            if (item == null)
            {
                return false;
            }
            else
            {
                CleanTrackingHelper.Clean<StudentGrade>(context);
                context.Entry(paraObject).State = EntityState.Modified;
                await context.SaveChangesAsync();
                CleanTrackingHelper.Clean<StudentGrade>(context);
                return true;
            }

        }

        public async Task<bool> DeleteAsync(StudentGrade paraObject)
        {
            StudentGrade item = await context.StudentGrade
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.EnrollmentId == paraObject.EnrollmentId);
            if (item == null)
            {
                return false;
            }
            else
            {
                CleanTrackingHelper.Clean<StudentGrade>(context);
                context.Entry(item).State = EntityState.Deleted;
                await context.SaveChangesAsync();
                CleanTrackingHelper.Clean<StudentGrade>(context);
                return true;
            }
        }
    }
}

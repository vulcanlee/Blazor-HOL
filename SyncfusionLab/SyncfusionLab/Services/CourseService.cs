using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionLab.Services
{
    using EFCoreModel.Models;
    using Microsoft.EntityFrameworkCore;
    using SyncfusionLab.Extensions;

    public class CourseService : ICourseService
    {
        private readonly SchoolContext context;

        public CourseService(SchoolContext context)
        {
            this.context = context;
        }

        public Task<IQueryable<Course>> GetAsync()
        {
            return Task.FromResult(context.Course
                .AsNoTracking()
                .Include(x=>x.Department)
                .AsQueryable());
        }

        public async Task<Course> GetAsync(int id)
        {
            Course item = await context.Course
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.CourseId == id);
            return item;
        }

        public async Task<bool> AddAsync(Course paraObject)
        {
            await context.Course.AddAsync(paraObject);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Course paraObject)
        {
            Course item = await context.Course
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.CourseId == paraObject.CourseId);
            if (item == null)
            {
                return false;
            }
            else
            {
                context.CleanAllEFCoreTracking<Course>();
                context.Entry(paraObject).State = EntityState.Modified;

                // save 
                await context.SaveChangesAsync();
                return true;
            }

        }

        public async Task<bool> DeleteAsync(Course paraObject)
        {
            Course item = await context.Course
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.CourseId == paraObject.CourseId);
            if (item == null)
            {
                return false;
            }
            else
            {
                context.CleanAllEFCoreTracking<Course>();
                context.Course.Remove(item);
                await context.SaveChangesAsync();
                return true;
            }
        }
    }
}

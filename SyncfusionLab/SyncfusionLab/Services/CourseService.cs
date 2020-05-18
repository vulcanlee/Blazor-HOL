using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionLab.Services
{
    using EFCoreModel.Models;
    using Microsoft.EntityFrameworkCore;

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
                .AsNoTracking().AsQueryable());
        }

        public async Task<Course> GetAsync(int id)
        {
            Course item = await context.Course
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
                .FirstOrDefaultAsync(x => x.CourseId == paraObject.CourseId);
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
                var local = context.Set<Course>()
                    .Local
                    .FirstOrDefault(entry => entry.CourseId.Equals(paraObject.CourseId));

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

        public async Task<bool> DeleteAsync(Course paraObject)
        {
            Course item = await context.Course
                .FirstOrDefaultAsync(x => x.CourseId == paraObject.CourseId);
            if (item == null)
            {
                return false;
            }
            else
            {
                context.Course.Remove(item);
                await context.SaveChangesAsync();
                return true;
            }
        }
    }
}

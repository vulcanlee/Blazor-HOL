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
                .Include(x => x.Department)
                .FirstOrDefaultAsync(x => x.CourseId == id);
            return item;
        }

        public async Task<bool> AddAsync(Course paraObject)
        {
            CleanTrackingHelper.Clean<Course>(context);
            await context.Course
                .AddAsync(paraObject);
            await context.SaveChangesAsync();
            CleanTrackingHelper.Clean<Course>(context);
            return true;
        }

        public async Task<bool> UpdateAsync(Course paraObject)
        {
            #region EF Core 追蹤查詢所造成的問題說明
            // 若再進行搜尋該修改紀錄的時候，使用了 追蹤查詢 (也就是，沒有使用 .AsNoTracking()方法)
            // 將會造成快取記錄在電腦端，而這裡若要進行 
            // context.Entry(paraObject).State = EntityState.Modified; 呼叫與更新的時候
            // 將會造成問題
            // System.InvalidOperationException: The instance of entity type 'Person' cannot be tracked 
            // because another instance with the same key value for {'PersonId'} is already being tracked. 
            // When attaching existing entities, ensure that only one entity instance with a given key value
            // is attached. Consider using 'DbContextOptionsBuilder.EnableSensitiveDataLogging' 
            // to see the conflicting key values.
            #endregion

            CleanTrackingHelper.Clean<Course>(context);
            Course item = await context.Course
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.CourseId == paraObject.CourseId);
            if (item == null)
            {
                return false;
            }
            else
            {
                CleanTrackingHelper.Clean<Course>(context);
                context.Entry(paraObject).State = EntityState.Modified;
                await context.SaveChangesAsync();
                CleanTrackingHelper.Clean<Course>(context);
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
                CleanTrackingHelper.Clean<Course>(context);
                context.Entry(paraObject).State = EntityState.Deleted;
                await context.SaveChangesAsync();
                CleanTrackingHelper.Clean<Course>(context);
                return true;
            }
        }
    }
}

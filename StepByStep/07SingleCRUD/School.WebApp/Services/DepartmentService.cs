using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.WebApp.Services
{
    using ShareBusiness.Helpers;
    using EFCore.Models;
    using Microsoft.EntityFrameworkCore;

    public class DepartmentService : IDepartmentService
    {
        private readonly SchoolContext context;

        public DepartmentService(SchoolContext context)
        {
            this.context = context;
        }

        public Task<IQueryable<Department>> GetAsync()
        {
            return Task.FromResult(context.Department
                .AsNoTracking()
                .AsQueryable());
        }

        public async Task<Department> GetAsync(int id)
        {
            Department item = await context.Department
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.DepartmentId == id);
            return item;
        }

        public async Task<bool> AddAsync(Department paraObject)
        {
            CleanTrackingHelper.Clean<Department>(context);
            await context.Department
                .AddAsync(paraObject);
            await context.SaveChangesAsync();
            CleanTrackingHelper.Clean<Department>(context);
            return true;
        }

        public async Task<bool> UpdateAsync(Department paraObject)
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

            CleanTrackingHelper.Clean<Department>(context);
            Department item = await context.Department
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.DepartmentId == paraObject.DepartmentId);
            if (item == null)
            {
                return false;
            }
            else
            {
                CleanTrackingHelper.Clean<Department>(context);
                context.Entry(paraObject).State = EntityState.Modified;
                await context.SaveChangesAsync();
                CleanTrackingHelper.Clean<Department>(context);
                return true;
            }

        }

        public async Task<bool> DeleteAsync(Department paraObject)
        {
            CleanTrackingHelper.Clean<Department>(context);
            Department item = await context.Department
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.DepartmentId == paraObject.DepartmentId);
            if (item == null)
            {
                return false;
            }
            else
            {
                CleanTrackingHelper.Clean<Department>(context);
                context.Entry(paraObject).State = EntityState.Deleted;
                await context.SaveChangesAsync();
                CleanTrackingHelper.Clean<Department>(context);
                return true;
            }
        }
    }
}

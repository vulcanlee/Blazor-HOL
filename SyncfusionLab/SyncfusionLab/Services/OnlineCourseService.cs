using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionLab.Services
{
    using EFCoreModel.Models;
    using Microsoft.EntityFrameworkCore;

    public class OnlineCourseService : IOnlineCourseService
    {
        private readonly SchoolContext context;

        public OnlineCourseService(SchoolContext context)
        {
            this.context = context;
        }

        public Task<IQueryable<OnlineCourse>> GetAsync()
        {
            return Task.FromResult(context.OnlineCourse
                .Include(x=>x.Course)
                .AsNoTracking().AsQueryable());
        }

        public async Task<OnlineCourse> GetAsync(int id)
        {
            OnlineCourse item = await context.OnlineCourse
                .FirstOrDefaultAsync(x => x.OnlineCourseId == id);
            return item;
        }

        public async Task<bool> AddAsync(OnlineCourse paraObject)
        {
            await context.OnlineCourse.AddAsync(paraObject);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(OnlineCourse paraObject)
        {
            OnlineCourse item = await context.OnlineCourse
                .FirstOrDefaultAsync(x => x.OnlineCourseId == paraObject.OnlineCourseId);
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
                var local = context.Set<OnlineCourse>()
                    .Local
                    .FirstOrDefault(entry => entry.OnlineCourseId.Equals(paraObject.OnlineCourseId));

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

        public async Task<bool> DeleteAsync(OnlineCourse paraObject)
        {
            OnlineCourse item = await context.OnlineCourse
                .FirstOrDefaultAsync(x => x.OnlineCourseId == paraObject.OnlineCourseId);
            if (item == null)
            {
                return false;
            }
            else
            {
                context.OnlineCourse.Remove(item);
                await context.SaveChangesAsync();
                return true;
            }
        }
    }
}

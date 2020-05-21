using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatBlazorLab.Services
{
    using EFCoreModel.Models;
    using Microsoft.EntityFrameworkCore;

    public class OutlineService : IOutlineService
    {
        private readonly SchoolContext context;

        public OutlineService(SchoolContext context)
        {
            this.context = context;
        }

        public Task<IQueryable<Outline>> GetAsync()
        {
            return Task.FromResult(context.Outline
                .Include(x => x.Course)
                .AsNoTracking().AsQueryable());
        }

        public Task<IQueryable<Outline>> GetByHeaderIDAsync(int headerID)
        {
            return Task.FromResult(context.Outline
                .Include(x => x.Course)
                .Where(x=>x.CourseId == headerID)
                .AsNoTracking().AsQueryable());
        }

        public async Task<Outline> GetAsync(int id)
        {
            Outline item = await context.Outline
                .FirstOrDefaultAsync(x => x.OutlineId == id);
            return item;
        }

        public async Task<bool> AddAsync(Outline paraObject)
        {
            await context.Outline.AddAsync(paraObject);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Outline paraObject)
        {
            Outline item = await context.Outline
                .FirstOrDefaultAsync(x => x.OutlineId == paraObject.OutlineId);
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
                var local = context.Set<Outline>()
                    .Local
                    .FirstOrDefault(entry => entry.OutlineId.Equals(paraObject.OutlineId));

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

        public async Task<bool> DeleteAsync(Outline paraObject)
        {
            Outline item = await context.Outline
                .FirstOrDefaultAsync(x => x.OutlineId == paraObject.OutlineId);
            if (item == null)
            {
                return false;
            }
            else
            {
                context.Outline.Remove(item);
                await context.SaveChangesAsync();
                return true;
            }
        }
    }
}

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
                .AsNoTracking()
                .Include(x => x.Course)
                .AsQueryable());
        }

        public Task<IQueryable<Outline>> GetByHeaderIDAsync(int id)
        {
            return Task.FromResult(context.Outline
                .AsNoTracking()
                .Include(x => x.Course)
                .Where(x => x.CourseId == id)
                .AsQueryable());
        }

        public async Task<Outline> GetAsync(int id)
        {
            Outline item = await context.Outline
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.OutlineId == id);
            return item;
        }

        public Task<bool> BeforeAddCheckAsync(Outline paraObject)
        {
            return Task.FromResult(true);
        }

        public async Task<bool> AddAsync(Outline paraObject)
        {
            CleanTrackingHelper.Clean<Outline>(context);
            await context.Outline.AddAsync(paraObject);
            await context.SaveChangesAsync();
            CleanTrackingHelper.Clean<Outline>(context);
            return true;
        }

        public Task<bool> BeforeUpdateCheckAsync(Outline paraObject)
        {
            return Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(Outline paraObject)
        {
            CleanTrackingHelper.Clean<Outline>(context);
            Outline item = await context.Outline
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.OutlineId == paraObject.OutlineId);
            if (item == null)
            {
                return false;
            }
            else
            {
                CleanTrackingHelper.Clean<Outline>(context);
                context.Entry(paraObject).State = EntityState.Modified;
                await context.SaveChangesAsync();
                CleanTrackingHelper.Clean<Outline>(context);
                return true;
            }

        }

        public async Task<bool> DeleteAsync(Outline paraObject)
        {
            Outline item = await context.Outline
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.OutlineId == paraObject.OutlineId);
            if (item == null)
            {
                return false;
            }
            else
            {
                CleanTrackingHelper.Clean<Outline>(context);
                context.Entry(item).State = EntityState.Deleted;
                await context.SaveChangesAsync();
                CleanTrackingHelper.Clean<Outline>(context);
                return true;
            }
        }
    }
}

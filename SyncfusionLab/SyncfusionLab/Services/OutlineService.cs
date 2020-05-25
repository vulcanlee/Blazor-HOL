using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionLab.Services
{
    using EFCoreModel.Models;
    using Microsoft.EntityFrameworkCore;
    using SyncfusionLab.Extensions;

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
                .Include(x=>x.Course)
                .AsQueryable());
        }

        public async Task<Outline> GetAsync(int id)
        {
            Outline item = await context.Outline
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.OutlineId == id);
            return item;
        }
        public Task<IQueryable<Outline>> GetByHeaderIDAsync(int paraObj)
        {
            return Task.FromResult(context.Outline
                .AsNoTracking()
                .Where(x => x.CourseId == paraObj)
                .Include(x => x.Course)
                .AsQueryable());
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
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.OutlineId == paraObject.OutlineId);
            if (item == null)
            {
                return false;
            }
            else
            {
                context.CleanAllEFCoreTracking<Outline>();
                context.Entry(paraObject).State = EntityState.Modified;

                // save 
                await context.SaveChangesAsync();
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
                context.CleanAllEFCoreTracking<Outline>();
                context.Outline.Remove(item);
                await context.SaveChangesAsync();
                return true;
            }
        }
    }
}

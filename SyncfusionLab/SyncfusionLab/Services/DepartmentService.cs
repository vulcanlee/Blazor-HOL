using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionLab.Services
{
    using EFCoreModel.Models;
    using Microsoft.EntityFrameworkCore;
    using SyncfusionLab.Extensions;

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
            await context.Department.AddAsync(paraObject);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Department paraObject)
        {
            Department item = await context.Department
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.DepartmentId == paraObject.DepartmentId);
            if (item == null)
            {
                return false;
            }
            else
            {
                context.CleanAllEFCoreTracking<Department>();
                context.Entry(paraObject).State = EntityState.Modified;

                // save 
                await context.SaveChangesAsync();
                return true;
            }

        }

        public async Task<bool> DeleteAsync(Department paraObject)
        {
            Department item = await context.Department
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.DepartmentId == paraObject.DepartmentId);
            if (item == null)
            {
                return false;
            }
            else
            {
                context.CleanAllEFCoreTracking<Department>();
                context.Department.Remove(item);
                await context.SaveChangesAsync();
                return true;
            }
        }
    }
}

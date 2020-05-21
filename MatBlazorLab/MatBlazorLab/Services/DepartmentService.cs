using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatBlazorLab.Services
{
    using EFCoreModel.Models;
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
                .AsNoTracking().AsQueryable());
        }

        public async Task<Department> GetAsync(int id)
        {
            Department item = await context.Department
                .FirstOrDefaultAsync(x => x.DepartmentId == id);
            return item;
        }

        public Person GetAdministrator(int id)
        {
            Person item =  context.Person
                .FirstOrDefault(x => x.PersonId == id);
            return item;
        }

        public async Task<bool> AddAsync(Department paraObject)
        {
            try
            {
                await context.Department.AddAsync(paraObject);
                await context.SaveChangesAsync();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return true;
        }

        public async Task<bool> UpdateAsync(Department paraObject)
        {
            Department item = await context.Department
                .FirstOrDefaultAsync(x => x.DepartmentId == paraObject.DepartmentId);
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
                var local = context.Set<Department>()
                    .Local
                    .FirstOrDefault(entry => entry.DepartmentId.Equals(paraObject.DepartmentId));

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

        public async Task<bool> DeleteAsync(Department paraObject)
        {
            Department item = await context.Department
                .FirstOrDefaultAsync(x => x.DepartmentId == paraObject.DepartmentId);
            if (item == null)
            {
                return false;
            }
            else
            {
                context.Department.Remove(item);
                await context.SaveChangesAsync();
                return true;
            }
        }
    }
}

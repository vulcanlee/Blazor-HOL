using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionLab.Services
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

        public Task<IQueryable<Person>> GetAsync()
        {
            return Task.FromResult(context.Person
                .AsNoTracking().AsQueryable());
        }

        public async Task<Person> GetAsync(int id)
        {
            Person item = await context.Person
                .FirstOrDefaultAsync(x => x.PersonId == id);
            return item;
        }

        public async Task<bool> AddAsync(Person paraObject)
        {
            await context.Person.AddAsync(paraObject);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Person paraObject)
        {
            Person item = await context.Person
                .FirstOrDefaultAsync(x => x.PersonId == paraObject.PersonId);
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
                var local = context.Set<Person>()
                    .Local
                    .FirstOrDefault(entry => entry.PersonId.Equals(paraObject.PersonId));

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

        public async Task<bool> DeleteAsync(Person paraObject)
        {
            Person item = await context.Person
                .FirstOrDefaultAsync(x => x.PersonId == paraObject.PersonId);
            if (item == null)
            {
                return false;
            }
            else
            {
                context.Person.Remove(item);
                await context.SaveChangesAsync();
                return true;
            }
        }
    }
}

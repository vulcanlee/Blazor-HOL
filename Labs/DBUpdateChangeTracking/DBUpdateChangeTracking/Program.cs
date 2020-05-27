using DBUpdateChangeTracking.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DBUpdateChangeTracking
{
    class Program
    {
        static SchoolContext context = new SchoolContext();
        static async Task Main(string[] args)
        {
            #region 新增一筆 person (Last Name: Lee , First Name : Vulcan)
            Person person = new Person()
            {
                LastName = "Lee",
                FirstName = "Vulcan",
                HireDate = DateTime.Now
            };
            context.Add(person);
            await context.SaveChangesAsync();
            Console.WriteLine($"Vulcan Lee 已經新增");
            ShowChangeTracking();
            #endregion

            #region 修改 person (Last Name: Lee , First Name : Avatar)
            Person searchPerson = await context.Person.FirstOrDefaultAsync(x => x.FirstName == "Vulcan");
            Console.WriteLine($"Vulcan Lee 已經查詢出來");
            ShowChangeTracking();
            Person updatePerson = searchPerson.Clone();
            updatePerson.LastName = "Hu";
            updatePerson.FirstName = "Avatar";
            await DoModifyPerson(updatePerson);
            Console.WriteLine($"Vulcan Lee 已經更新為 Avatar Hu");
            ShowChangeTracking();
            #endregion

            #region 刪除 person (Last Name: Lee , First Name : Avatar)
            await DoDeletePerson(updatePerson);
            Console.WriteLine($"Avatar Hu 已經刪除");
            ShowChangeTracking();
            #endregion
        }

        private static async Task DoModifyPerson(Person updatePerson)
        {
            #region 解除變更追蹤紀錄
            var local = context.Set<Person>()
                .Local.FirstOrDefault(x=>x.PersonId == updatePerson.PersonId);
            if(local!= null)
            {
                context.Entry(local).State = EntityState.Detached;
            }
            #endregion
            context.Entry(updatePerson).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        private static async Task DoDeletePerson(Person updatePerson)
        {
            #region 解除變更追蹤紀錄
            var local = context.Set<Person>()
                .Local.FirstOrDefault(x => x.PersonId == updatePerson.PersonId);
            if (local != null)
            {
                context.Entry(local).State = EntityState.Detached;
            }
            #endregion
            context.Entry(updatePerson).State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }

        private static void ShowChangeTracking()
        {
            #region 變更追蹤紀錄
            var locals = context.Set<Person>()
                .Local;
            if (locals.Count > 0)
            {
                foreach (var item in locals)
                {
                    Console.WriteLine($"變更追蹤紀錄 : {item.FirstName} {item.LastName}");
                }
            }
            else
            {
                Console.WriteLine($"沒有發現任何變更追蹤紀錄");
            }
            #endregion
        }
    }
}

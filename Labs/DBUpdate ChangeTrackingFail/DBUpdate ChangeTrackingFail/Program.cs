using DBUpdate_ChangeTrackingFail.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DBUpdate_ChangeTrackingFail
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
            #endregion

            #region 修改 person (Last Name: Lee , First Name : Avatar)
            Person searchPerson = await context.Person.FirstOrDefaultAsync(x => x.FirstName == "Vulcan");
            Person updatePerson = searchPerson.Clone();
            updatePerson.LastName = "Hu";
            updatePerson.FirstName = "Avatar";
            await DoModifyPerson(updatePerson);
            Console.WriteLine($"Vulcan Lee 已經更新為 Avatar Hu");
            #endregion

            #region 刪除 person (Last Name: Lee , First Name : Avatar)
            await DoDeletePerson(updatePerson);
            Console.WriteLine($"Avatar Hu 已經刪除");

            #endregion
        }

        private static async Task DoModifyPerson(Person updatePerson)
        {
            context.Entry(updatePerson).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        private static async Task DoDeletePerson(Person updatePerson)
        {
            context.Entry(updatePerson).State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }
    }
}

using DBEntityFrameworkCoreCRUD.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DBEntityFrameworkCoreCRUD
{
    class Program
    {
        static async Task Main(string[] args)
        {
            SchoolContext context = new SchoolContext();

            #region Phase 1 : 新增與查詢
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

            #region 查詢所有名子為 Vulcan 的人員，確認紀錄有新增成功
            var people = await context.Person.Where(x => x.FirstName == "Vulcan").ToListAsync();
            Console.WriteLine($"列出所有名為 Vulcan 的紀錄");
            foreach (var item in people)
            {
                Console.WriteLine($"人員: {item.FirstName} {item.LastName}");
            }
            #endregion
            #endregion

            #region Phase 2 : 修改與查詢
            #region 查詢出剛剛新增紀錄，修改為 Vulcan 為 Avatar
            person = await context.Person.FirstOrDefaultAsync(x=>x.FirstName == "Vulcan");
            person.FirstName = "Avatar";
            await context.SaveChangesAsync();
            Console.WriteLine($"Vulcan Lee 已經修改為 Avatar Lee");
            #endregion

            #region 查詢所有名子為 Avatar 的人員，確認紀錄有修改成功
            people = await context.Person.Where(x => x.FirstName == "Avatar").ToListAsync();
            Console.WriteLine($"列出所有名為 Avatar 的紀錄");
            foreach (var item in people)
            {
                Console.WriteLine($"人員: {item.FirstName} {item.LastName}");
            }
            #endregion
            #endregion

            #region Phase 3 : 刪除與查詢
            #region 查詢出剛剛修改紀錄，並且將這筆紀錄刪除
            person = await context.Person.FirstOrDefaultAsync(x => x.FirstName == "Avatar");
            context.Person.Remove(person);
            await context.SaveChangesAsync();
            Console.WriteLine($"Avatar Lee 已經刪除");
            #endregion

            #region 查詢所有名子為 Avatar 的人員，確認紀錄有刪除成功
            people = await context.Person.Where(x => x.FirstName == "Avatar").ToListAsync();
            Console.WriteLine($"列出所有名為 Avatar 的紀錄");
            foreach (var item in people)
            {
                Console.WriteLine($"人員: {item.FirstName} {item.LastName}");
            }
            #endregion
            #endregion
        }
    }
}

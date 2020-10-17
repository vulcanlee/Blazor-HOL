using efCodeFirst.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Linq;

namespace efCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new DataContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Department department1 = new Department() { Name = "新增的科系1", };
            context.Department.Add(department1);
            context.SaveChanges();
            Department department2 = context.Department.First();
            department2.Name = "修改該科系名稱";
            context.SaveChanges();
            Reset(context); // 清除 ChangeTracker 內的科系紀錄
            Department department3 = new Department()
            {
                Id = department1.Id,
                Name = "使用狀態來修改的科系名稱",
            };
            context.Department.Update(department3);
            //context.Entry(department3).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            foreach (var item in context.Department.ToList())
            {
                Console.WriteLine($"科系名稱:{item.Name}");
            }
        }
        public static void Reset(DataContext context)
        {
            #region 解除快取紀錄
            foreach (var item in context
                .Set<Department>().Local.ToList())
            {
                context.Entry(item).State = 
                    Microsoft.EntityFrameworkCore.EntityState.Detached;
            }
            #endregion
        }
    }
}

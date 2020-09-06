using efCodeFirst.Models;
using Microsoft.EntityFrameworkCore;
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

            context.Department.Add(new Department());
            context.Entry(new Department()).State = EntityState.Added;
            context.SaveChanges();
            Console.WriteLine($"科系記錄數量:{context.Department.ToList().Count}");
            var departments = context.Department.ToList();
            Reset(context); // 清除 ChangeTracker 內的科系紀錄
            context.Department.Remove(departments[0]);
            context.Entry(departments[1]).State = EntityState.Deleted;
            context.SaveChanges();
            Console.WriteLine($"科系記錄數量:{context.Department.ToList().Count}");
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

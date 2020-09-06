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

            Department department1 = new Department()
            {
                Name = "新增的科系1",
            };
            context.Department.Add(department1);
            context.SaveChanges();
            Department department2 = new Department()
            {
                Name = "新增的科系2",
            };
            context.Entry(department2).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            context.SaveChanges();
            foreach (var item in context.Department.ToList())
            {
                Console.WriteLine($"科系名稱:{item.Name}");
            }
        }
    }
}

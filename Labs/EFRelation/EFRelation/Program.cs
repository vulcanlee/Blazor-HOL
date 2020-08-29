using EFRelation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EFRelation
{
    class Program
    {
        static async Task Main(string[] args)
        {
            SchoolContext SchoolContext = new SchoolContext();
            var allCourse = await SchoolContext.Course
                .AsNoTracking()
                .Include(x=>x.Department)
                .ToListAsync();
            foreach (var itemCourse in allCourse)
            {
                Console.WriteLine($"Course : {itemCourse.Title}");
                if(itemCourse.Department!= null)
                {
                    Console.WriteLine($"Department : {itemCourse.Department.Name}");
                }
            }
        }
    }
}

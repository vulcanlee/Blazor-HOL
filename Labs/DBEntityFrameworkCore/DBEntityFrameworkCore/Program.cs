using DBEntityFrameworkCore.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DBEntityFrameworkCore
{
    class Program
    {
        static async Task Main(string[] args)
        {
            SchoolContext context = new SchoolContext();
            var people = await context.Person
                .OrderBy(x=>x.LastName)
                .ThenBy(x=>x.FirstName)
                .Where(x=>x.LastName == "Li")
                .ToListAsync();

            var foo = context.Person
                .OrderBy(x=>x.LastName);
            foo = foo.ThenBy(z => z.FirstName);
            var bar = foo.Where(x => x.LastName == "Li");
            var bar1 = bar.ToList();
            foreach (var item in people)
            {
                Console.WriteLine($"人員:{item.LastName} {item.FirstName}");
            }
        }
    }
}

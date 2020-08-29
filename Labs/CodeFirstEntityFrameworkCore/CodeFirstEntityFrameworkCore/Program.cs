using DatabaseModel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstEntityFrameworkCore
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var content = File.ReadAllText("Init.txt");

            SchoolContext context = new SchoolContext();
            Console.WriteLine("Delete Database");
            await context.Database.EnsureDeletedAsync();
            Console.WriteLine("Create Database");
            await context.Database.EnsureCreatedAsync();

            Console.WriteLine("Create Testing Data");
            context.Database.ExecuteSqlCommand(content);
            foreach (var item in context.Course)
            {
                Console.WriteLine($"{item.Title}");
            }
        }
    }
}

using efLoggerFactory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace efLoggerFactory
{
    class Program
    {
        public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=School";
            DbContextOptions<SchoolContext> options = new DbContextOptionsBuilder<SchoolContext>()
                .UseLoggerFactory(MyLoggerFactory)
                .UseSqlServer(connectionString)
                .Options;
            using (var context = new SchoolContext(options))
            {
                Console.WriteLine($"取得 StudentGrade 第一筆紀錄");
                var aStudentGrade = context.StudentGrade.FirstOrDefault();
                Console.WriteLine($"更新成績為 4.99");
                aStudentGrade.Grade = 4.99m;
                context.SaveChanges();
            }
        }
    }
}

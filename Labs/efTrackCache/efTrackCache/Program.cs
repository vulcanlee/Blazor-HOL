using efTrackCache.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace efTrackCache
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SchoolContext())
            {
                Console.WriteLine($"查詢第一筆 StudentGrade 紀錄");
                var studentGrade = context.StudentGrade.FirstOrDefault();
                studentGrade.Grade = 3.2m;
                context.Entry(studentGrade).State = EntityState.Modified;
                DisplayStates(context.ChangeTracker.Entries());
                Console.WriteLine($"EnrollmentId={studentGrade.EnrollmentId}" +
                    $" 成績為 :{studentGrade.Grade}");

                Console.WriteLine($"請手動更新這筆紀錄" +
                    $"(EnrollmentId={studentGrade.EnrollmentId}，再按下任一按鍵");
                Console.ReadKey();

                Console.WriteLine($"重新查詢第一筆 StudentGrade 紀錄 ");
                studentGrade = context.StudentGrade.FirstOrDefault();
                Console.WriteLine($"重新查詢 EnrollmentId={studentGrade.EnrollmentId} " +
                    $"成績為 :{studentGrade.Grade}");
            }
        }
        private static void DisplayStates(IEnumerable<EntityEntry> entries)
        {
            foreach (var entry in entries)
            {
                Console.WriteLine($"Entity: {entry.Entity.GetType().Name}," +
                    $"State: { entry.State.ToString()}");
            }
        }
    }
}

using efChangeTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace efChangeTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SchoolContext())
            {
                Console.WriteLine($"執行任何資料庫存取動作前的 ChangeTracker");
                DisplayStates(context.ChangeTracker.Entries());
                Console.WriteLine($"查詢第一筆 Person 紀錄，但使用 AsNoTracking");
                var person = context.Person.FirstOrDefault();
                var people = context.Person.ToList();
                DisplayStates(context.ChangeTracker.Entries());
                Console.WriteLine($"查詢第一筆 Person 紀錄 ");
                person = context.Person.FirstOrDefault();
                DisplayStates(context.ChangeTracker.Entries());
                Console.WriteLine($"修改與更新 Person 紀錄 ");
                person.LastName = $"{person.LastName}1";
                DisplayStates(context.ChangeTracker.Entries());
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

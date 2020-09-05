using efCodeFirst.Models;
using System;

namespace efCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new DataContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}

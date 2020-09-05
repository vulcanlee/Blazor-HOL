using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace efCodeFirst.Models
{
    public class DataContext : DbContext
    {
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentGrade> Grade { get; set; }
        public virtual DbSet<StudentAddress> StudentAddress { get; set; }

        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SchoolCodeFirst");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

    }
}

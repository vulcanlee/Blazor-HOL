using System;
using System.Collections.Generic;
using System.Text;

namespace efCodeFirst.Models
{
    public class Student
    {
        public Student()
        {
            StudentGrades = new HashSet<StudentGrade>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual StudentAddress Address { get; set; }
        public virtual ICollection<StudentGrade> StudentGrades { get; set; }
    }
}

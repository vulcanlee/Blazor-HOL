using System;
using System.Collections.Generic;
using System.Text;

namespace efCodeFirst.Models
{
    public class Course
    {
        public Course()
        {
            StudentGrades = new HashSet<StudentGrade>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<StudentGrade> StudentGrades { get; set; }
    }
}

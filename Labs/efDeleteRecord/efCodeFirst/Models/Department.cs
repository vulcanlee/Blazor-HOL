using System;
using System.Collections.Generic;
using System.Text;

namespace efCodeFirst.Models
{
    public class Department
    {
        public Department()
        {
            Courses = new HashSet<Course>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace EFCoreModel.Models
{
    public partial class Course
    {
        public Course()
        {
            CourseInstructor = new HashSet<CourseInstructor>();
            OnlineCourse = new HashSet<OnlineCourse>();
            StudentGrade = new HashSet<StudentGrade>();
        }

        public int CourseId { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual OnsiteCourse OnsiteCourse { get; set; }
        public virtual ICollection<CourseInstructor> CourseInstructor { get; set; }
        public virtual ICollection<OnlineCourse> OnlineCourse { get; set; }
        public virtual ICollection<StudentGrade> StudentGrade { get; set; }
    }
}

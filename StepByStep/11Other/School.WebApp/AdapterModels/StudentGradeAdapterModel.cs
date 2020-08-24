using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School.WebApp.AdapterModels
{
    public class StudentGradeAdapterModel
    {
        public int EnrollmentId { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; } = "";
        public int StudentId { get; set; }
        public string StudentName { get; set; } = "";
        public decimal? Grade { get; set; }

        public CourseAdapterModel Course { get; set; }
        public PersonAdapterModel Student { get; set; }
    }
}

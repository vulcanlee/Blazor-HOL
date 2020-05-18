using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionLab.AdaptorModels
{
    using System.ComponentModel.DataAnnotations;
    public class StudentGradeAdaptorModel
    {
        public int EnrollmentId { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public decimal? Grade { get; set; }
        [Required(ErrorMessage = "學生 欄位必須要存在，請點選問號來選取")]
        public string StudentName { get; set; } = "";
        public string CourseName { get; set; } = "";
    }
}

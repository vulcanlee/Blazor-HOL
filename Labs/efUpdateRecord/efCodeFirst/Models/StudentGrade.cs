using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace efCodeFirst.Models
{
    public class StudentGrade
    {
        public StudentGrade()
        {
        }

        public int Id { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Grade { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace EFCoreModel.Models
{
    public partial class OnlineCourse
    {
        public int OnlineCourseId { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; }

        public virtual Course Course { get; set; }
    }
}

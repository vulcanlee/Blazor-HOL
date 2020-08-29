using System;
using System.Collections.Generic;

namespace EFRelation.Models
{
    public partial class CourseInstructor
    {
        public int CourseId { get; set; }
        public int PersonId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Person Person { get; set; }
    }
}

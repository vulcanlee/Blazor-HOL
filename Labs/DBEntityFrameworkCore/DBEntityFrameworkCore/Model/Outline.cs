using System;
using System.Collections.Generic;

namespace DBEntityFrameworkCore.Model
{
    public partial class Outline
    {
        public int OutlineId { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; }

        public virtual Course Course { get; set; }
    }
}

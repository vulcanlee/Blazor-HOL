using System;
using System.Collections.Generic;

namespace DBUpdate_ChangeTrackingFail.Model
{
    public partial class OnsiteCourse
    {
        public int CourseId { get; set; }
        public string Location { get; set; }
        public string Days { get; set; }
        public DateTime Time { get; set; }

        public virtual Course Course { get; set; }
    }
}

using SyncfusionLab.RazorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionLab.Helpers
{
    public class CourseSortHelper
    {
        public static void Initialization(List<SortCondition> SortConditions)
        {
            SortConditions.Clear();
            SortConditions.Add(new SortCondition()
            {
                Id = "Course Name Ascending",
                Title = "課程名稱 遞增"
            });
            SortConditions.Add(new SortCondition()
            {
                Id = "Course Name Descending",
                Title = "課程名稱 遞減"
            });
            SortConditions.Add(new SortCondition()
            {
                Id = "Department Name Ascending",
                Title = "科系 遞增"
            });
            SortConditions.Add(new SortCondition()
            {
                Id = "Department Name Descending",
                Title = "科系 遞減"
            });
        }
    }
}

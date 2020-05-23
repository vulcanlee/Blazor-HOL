using SyncfusionLab.RazorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionLab.Helpers
{
    public class StudentGradeSortHelper
    {
        public static void Initialization(List<SortCondition> SortConditions)
        {
            SortConditions.Clear();
            SortConditions.Add(new SortCondition()
            {
                Id = "Grade Ascending",
                Title = "分數 遞增"
            });
            SortConditions.Add(new SortCondition()
            {
                Id = "Grade Descending",
                Title = "分數 遞減"
            });
            SortConditions.Add(new SortCondition()
            {
                Id = "Name Ascending",
                Title = "姓名 遞增"
            });
            SortConditions.Add(new SortCondition()
            {
                Id = "Name Descending",
                Title = "姓名 遞減"
            });
            SortConditions.Add(new SortCondition()
            {
                Id = "Student Ascending",
                Title = "學生身分排序"
            });
        }
    }
}

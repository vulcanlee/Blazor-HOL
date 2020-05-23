using SyncfusionLab.RazorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionLab.Helpers
{
    public enum StudentGradeEnum
    {
        GradeAscending,
        GradeDescending,
        NameAscending,
        NameDescending,
        StudentAscending,
    }
    public class StudentGradeSortHelper
    {
        public static void Initialization(List<SortCondition> SortConditions)
        {
            SortConditions.Clear();
            SortConditions.Add(new SortCondition()
            {
                Id = (int)StudentGradeEnum.GradeAscending,
                Title = "分數 遞增"
            });
            SortConditions.Add(new SortCondition()
            {
                Id = (int)StudentGradeEnum.GradeDescending,
                Title = "分數 遞減"
            });
            SortConditions.Add(new SortCondition()
            {
                Id = (int)StudentGradeEnum.NameAscending,
                Title = "姓名 遞增"
            });
            SortConditions.Add(new SortCondition()
            {
                Id = (int)StudentGradeEnum.NameDescending,
                Title = "姓名 遞減"
            });
            SortConditions.Add(new SortCondition()
            {
                Id = (int)StudentGradeEnum.StudentAscending,
                Title = "學生身分排序"
            });
        }
    }
}

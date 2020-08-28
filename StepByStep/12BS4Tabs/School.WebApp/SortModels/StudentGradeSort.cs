using ShareDomain.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.WebApp.SortModels
{
    public enum StudentGradeSortEnum
    {
        GradeAscending,
        GradeDescending,
    }
    public class StudentGradeSort
    {
        public static void Initialization(List<SortCondition> SortConditions)
        {
            SortConditions.Clear();
            SortConditions.Add(new SortCondition()
            {
                Id = (int)StudentGradeSortEnum.GradeAscending,
                Title = "成績 遞增"
            });
            SortConditions.Add(new SortCondition()
            {
                Id = (int)StudentGradeSortEnum.GradeDescending,
                Title = "成績 遞減"
            });
        }
    }
}

using SyncfusionLab.RazorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionLab.Helpers
{
    public enum CourseSortEnum
    {
        CourseNameAscending,
        CourseNameDescending,
        DepartmentNameAscending,
        DepartmentNameDescending,
    }
    public class CourseSortHelper
    {
        public static void Initialization(List<SortCondition> SortConditions)
        {
            SortConditions.Clear();
            SortConditions.Add(new SortCondition()
            {
                Id = (int)CourseSortEnum.CourseNameAscending,
                Title = "課程名稱 遞增"
            });
            SortConditions.Add(new SortCondition()
            {
                Id = (int)CourseSortEnum.CourseNameDescending,
                Title = "課程名稱 遞減"
            });
            SortConditions.Add(new SortCondition()
            {
                Id = (int)CourseSortEnum.DepartmentNameAscending,
                Title = "科系 遞增"
            });
            SortConditions.Add(new SortCondition()
            {
                Id = (int)CourseSortEnum.DepartmentNameDescending,
                Title = "科系 遞減"
            });
        }
    }
}

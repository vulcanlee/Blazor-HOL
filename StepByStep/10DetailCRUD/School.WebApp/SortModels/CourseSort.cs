using ShareDomain.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.WebApp.SortModels
{
    public enum CourseSortEnum
    {
        TitleAscending,
        TitleDescending,
        CreditsAscending,
        CreditsDescending,
    }
    public class CourseSort
    {
        public static void Initialization(List<SortCondition> SortConditions)
        {
            SortConditions.Clear();
            SortConditions.Add(new SortCondition()
            {
                Id = (int)CourseSortEnum.TitleAscending,
                Title = "名稱 遞增"
            });
            SortConditions.Add(new SortCondition()
            {
                Id = (int)CourseSortEnum.TitleDescending,
                Title = "名稱 遞減"
            });
            SortConditions.Add(new SortCondition()
            {
                Id = (int)CourseSortEnum.CreditsAscending,
                Title = "學分 遞增"
            });
            SortConditions.Add(new SortCondition()
            {
                Id = (int)CourseSortEnum.CreditsDescending,
                Title = "學分 遞減"
            });
        }
    }
}

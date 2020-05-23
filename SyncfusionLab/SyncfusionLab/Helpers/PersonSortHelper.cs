using SyncfusionLab.RazorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionLab.Helpers
{
    public enum PersonEnum
    {
        NameAscending,
        NameDescending,
        StudentAscending,
        EmployeeAscending,
    }
    public class PersonSortHelper
    {
        public static void Initialization(List<SortCondition> SortConditions)
        {
            SortConditions.Clear();
            SortConditions.Add(new SortCondition()
            {
                Id = (int)PersonEnum.NameAscending,
                Title = "姓名 遞增"
            });
            SortConditions.Add(new SortCondition()
            {
                Id = (int)PersonEnum.NameDescending,
                Title = "姓名 遞減"
            });
            SortConditions.Add(new SortCondition()
            {
                Id = (int)PersonEnum.StudentAscending,
                Title = "學生身分排序"
            });
            SortConditions.Add(new SortCondition()
            {
                Id = (int)PersonEnum.EmployeeAscending,
                Title = "職員身分排序"
            });
        }
    }
}

using SyncfusionLab.RazorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionLab.Helpers
{
    public enum DepartmentEnum
    {
        NameAscending,
        NameDescending,
        BudgetAscending,
        BudgetDescending,
    }
    public class DepartmentSortHelper
    {
        public static void Initialization(List<SortCondition> SortConditions)
        {
            SortConditions.Clear();
            SortConditions.Add(new SortCondition()
            {
                Id = (int)DepartmentEnum.NameAscending,
                Title = "名稱 遞增"
            });
            SortConditions.Add(new SortCondition()
            {
                Id = (int)DepartmentEnum.NameDescending,
                Title = "名稱 遞減"
            });
            SortConditions.Add(new SortCondition()
            {
                Id = (int)DepartmentEnum.BudgetAscending,
                Title = "預算 遞增"
            });
            SortConditions.Add(new SortCondition()
            {
                Id = (int)DepartmentEnum.BudgetDescending,
                Title = "預算 遞減"
            });
        }
    }
}

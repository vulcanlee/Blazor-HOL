using ShareDomain.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.WebApp.SortModels
{
    public enum DepartmentSortEnum
    {
        NameAscending,
        NameDescending,
        BudgetAscending,
        BudgetDescending,
    }
    public class DepartmentSort
    {
        public static void Initialization(List<SortCondition> SortConditions)
        {
            SortConditions.Clear();
            SortConditions.Add(new SortCondition()
            {
                Id = (int)DepartmentSortEnum.NameAscending,
                Title = "名稱 遞增"
            });
            SortConditions.Add(new SortCondition()
            {
                Id = (int)DepartmentSortEnum.NameDescending,
                Title = "名稱 遞減"
            });
            SortConditions.Add(new SortCondition()
            {
                Id = (int)DepartmentSortEnum.BudgetAscending,
                Title = "預算 遞增"
            });
            SortConditions.Add(new SortCondition()
            {
                Id = (int)DepartmentSortEnum.BudgetDescending,
                Title = "預算 遞減"
            });
        }
    }
}

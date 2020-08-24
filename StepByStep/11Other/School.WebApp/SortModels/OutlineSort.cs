using ShareDomain.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.WebApp.SortModels
{
    public enum OutlineSortEnum
    {
        TitleAscending,
        TitleDescending,
    }
    public class OutlineSort
    {
        public static void Initialization(List<SortCondition> SortConditions)
        {
            SortConditions.Clear();
            SortConditions.Add(new SortCondition()
            {
                Id = (int)OutlineSortEnum.TitleAscending,
                Title = "名稱 遞增"
            });
            SortConditions.Add(new SortCondition()
            {
                Id = (int)OutlineSortEnum.TitleDescending,
                Title = "名稱 遞減"
            });
        }
    }
}

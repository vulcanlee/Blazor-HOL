using ShareDomain.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.WebApp.SortModels
{
    public enum PersonSortEnum
    {
        LastNameAscending,
        LastNameDescending,
        FirstNameAscending,
        FirstNameDescending,
    }
    public class PersonSort
    {
        public static void Initialization(List<SortCondition> SortConditions)
        {
            SortConditions.Clear();
            SortConditions.Add(new SortCondition()
            {
                Id = (int)PersonSortEnum.LastNameAscending,
                Title = "姓氏 遞增"
            });
            SortConditions.Add(new SortCondition()
            {
                Id = (int)PersonSortEnum.LastNameDescending,
                Title = "姓氏 遞減"
            });
            SortConditions.Add(new SortCondition()
            {
                Id = (int)PersonSortEnum.FirstNameAscending,
                Title = "名稱 遞增"
            });
            SortConditions.Add(new SortCondition()
            {
                Id = (int)PersonSortEnum.FirstNameDescending,
                Title = "名稱 遞減"
            });
        }
    }
}

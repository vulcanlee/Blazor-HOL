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
        HireDateAscending,
        HireDateDescending,
        EnrollmentDateAscending,
        EnrollmentDateDescending,
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
            SortConditions.Add(new SortCondition()
            {
                Id = (int)PersonSortEnum.HireDateAscending,
                Title = "到職日 遞增"
            });
            SortConditions.Add(new SortCondition()
            {
                Id = (int)PersonSortEnum.HireDateDescending,
                Title = "到職日 遞減"
            });
            SortConditions.Add(new SortCondition()
            {
                Id = (int)PersonSortEnum.EnrollmentDateAscending,
                Title = "入學註冊日 遞增"
            });
            SortConditions.Add(new SortCondition()
            {
                Id = (int)PersonSortEnum.EnrollmentDateDescending,
                Title = "入學註冊日 遞減"
            });
        }
    }
}

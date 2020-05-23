using SyncfusionLab.RazorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionLab.Helpers
{
    public enum OutlineEnum
    {
        TitleAscending,
        TitleDescending,
    }
    public class OutlineSortHelper
    {
        public static void Initialization(List<SortCondition> SortConditions)
        {
            SortConditions.Clear();
            SortConditions.Add(new SortCondition()
            {
                Id = (int)OutlineEnum.TitleAscending,
                Title = "名稱 遞增"
            });
            SortConditions.Add(new SortCondition()
            {
                Id = (int)OutlineEnum.TitleDescending,
                Title = "名稱 遞減"
            });
        }
    }
}

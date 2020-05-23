using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionLab.AdaptorModels
{
    using System.ComponentModel.DataAnnotations;
    public class CourseAdaptorModel
    {
        public int CourseId { get; set; }
        [Required(ErrorMessage = "名稱 欄位必須要輸入值")]
        public string Title { get; set; }
        [Required(ErrorMessage = "學分 欄位必須要輸入值")]
        public int Credits { get; set; }
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "科系 欄位必須要存在，請點選問號來選取")]
        public string DepartmentName { get; set; } = "";

        public bool IsExistCourse()
        {
            if (string.IsNullOrEmpty(Title))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}


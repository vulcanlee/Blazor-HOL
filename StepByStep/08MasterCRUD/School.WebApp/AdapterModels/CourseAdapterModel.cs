using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School.WebApp.AdapterModels
{
    public class CourseAdapterModel
    {
        public int CourseId { get; set; }
        [Required(ErrorMessage = "課程名稱 欄位必須要輸入值")]
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; } = "";

        public DepartmentAdapterModel Department { get; set; }
    }
}

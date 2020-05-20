using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionLab.AdaptorModels
{
    using System.ComponentModel.DataAnnotations;
    public class OutlineAdaptorModel
    {
        public int OutlineId { get; set; }
        public int CourseId { get; set; }
        [Required(ErrorMessage = "主題 欄位必須要輸入值")]
        public string Title { get; set; }
        [Required(ErrorMessage = "課程 欄位必須要存在，請點選問號來選取")]
        public string CourseTitle { get; set; }
    }
}

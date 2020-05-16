using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionLab.AdaptorModels
{
    using System.ComponentModel.DataAnnotations;
    public class PersonAdaptorModel
    {
        public int PersonId { get; set; }
        [Required(ErrorMessage = "名 欄位必須要輸入值")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "姓 欄位必須要輸入值")]
        public string FirstName { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? EnrollmentDate { get; set; }
    }
}

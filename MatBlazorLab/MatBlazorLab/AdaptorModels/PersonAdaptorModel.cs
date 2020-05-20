using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatBlazorLab.AdaptorModels
{
    using System.ComponentModel.DataAnnotations;
    public class PersonAdaptorModel:ICloneable
    {
        public int PersonId { get; set; }
        [Required(ErrorMessage = "名 欄位必須要輸入值")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "姓 欄位必須要輸入值")]
        public string FirstName { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public string FullName
        {
            get
            {
                return $"{LastName} {FirstName}";
            }
        }
        public string Kind
        {
            get
            {
                if (HireDate.HasValue)
                {
                    return "職員";
                }
                else
                {
                    return "學生";
                }
            }
        }

        public string CheckKindDate()
        {
            if (EnrollmentDate.HasValue == false && HireDate.HasValue == false)
            {
                return "註冊日期 與 雇用日期 兩者不可沒有輸入";
            }
            else if (EnrollmentDate.HasValue == true && HireDate.HasValue == true)
            {
                return "註冊日期 與 雇用日期 兩者僅能輸入一個";
            }
            else
            {
                return "";
            }
        }

        public PersonAdaptorModel Clone()
        {
            return ((ICloneable)this).Clone() as PersonAdaptorModel;
        }
        object ICloneable.Clone()
        {
            return this.MemberwiseClone();
        }
    }
}

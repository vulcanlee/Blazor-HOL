using ShareBusiness.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School.WebApp.AdapterModels
{
    public class PersonAdapterModel
    {
        public int PersonId { get; set; }
        [Required(ErrorMessage = "姓氏 欄位必須要輸入值")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "名稱 欄位必須要輸入值")]
        public string FirstName { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        public string PersonType
        {
            get
            {
                return MagicHelper.GetPersonTypeName(HireDate);
            }
        }
        public string PersonTypeAnother { get; set; } = "";

        public bool IsExist()
        {
            if (string.IsNullOrEmpty(FirstName))
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

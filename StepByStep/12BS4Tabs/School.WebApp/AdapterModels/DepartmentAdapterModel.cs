using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School.WebApp.AdapterModels
{
    public class DepartmentAdapterModel
    {
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "科系名稱 欄位必須要輸入值")]
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        public int? Administrator { get; set; }

        public string AdministratorName { get; set; } = "";

        public bool IsExist()
        {
            if (string.IsNullOrEmpty(Name))
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatBlazorLab.AdaptorModels
{
    using System.ComponentModel.DataAnnotations;
    public class DepartmentAdaptorModel:ICloneable
    {
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "名稱 欄位必須要輸入值")]
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        public int? Administrator { get; set; }
        public string FullName { get; set; } = "";

        public DepartmentAdaptorModel Clone()
        {
            return ((ICloneable)this).Clone() as DepartmentAdaptorModel;
        }
        object ICloneable.Clone()
        {
            return this.MemberwiseClone();
        }
    }
}

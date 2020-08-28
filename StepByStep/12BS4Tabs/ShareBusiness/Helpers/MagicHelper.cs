using System;
using System.Collections.Generic;
using System.Text;

namespace ShareBusiness.Helpers
{
    public static class MagicHelper
    {
        #region 定義神奇字串或者神奇數值
        public static readonly string AppName = "Contoso 大學管理系統";
        public static readonly string PersonInstructorTitle = "講師";
        public static readonly string PersonStudentTitle = "學生";
        public static readonly string DefaultConnectionString = "DefaultDbContext";
        public static readonly string PersonInstructor = "講師";
        public static readonly string PersonStudent = "學生";

        #endregion

        #region 支援方法
        public static string GetPersonTypeName(DateTime? HireDate)
        {
            if(HireDate.HasValue)
            {
                return PersonInstructor;
            }
            else
            {
                return PersonStudent;
            }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace xfLab.Models
{
    public class PersonData
    {
        public int PersonId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public string PersonType
        {
            get
            {
                if(HireDate.HasValue)
                {
                    return "職員";
                }
                else if(EnrollmentDate.HasValue)
                {
                    return "學生";
                }
                else
                {
                    return "無";
                }
            }
        }
    }
}

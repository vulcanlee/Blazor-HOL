using System;
using System.Collections.Generic;
using System.Text;

namespace efCodeFirst.Models
{
    public class StudentAddress
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}

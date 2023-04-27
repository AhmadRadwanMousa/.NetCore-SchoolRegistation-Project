using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolRegistration.Entity
{
    public partial class Class
    {
        public Class()
        {
            Students = new HashSet<Student>();
        }

        public int ClassId { get; set; }
        public string ClassNumber { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}

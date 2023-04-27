using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolRegistration.Entity
{
    public partial class Subject
    {
        public Subject()
        {
            StudentSubjects = new HashSet<StudentSubject>();
        }

        public int SubjectId { get; set; }
        public string SubjectName { get; set; }

        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}

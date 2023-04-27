using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolRegistration.Entity
{
    public partial class StudentSubject
    {
        public int StudentSubjectId { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }

        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}

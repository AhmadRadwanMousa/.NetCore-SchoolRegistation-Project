using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolRegistration.Entity
{
    public partial class Student
    {
        public Student()
        {
            StudentSubjects = new HashSet<StudentSubject>();
        }

        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int StudentAge { get; set; }
        public int ClassId { get; set; }
        public string MedicalIssues { get; set; }
        public string FatherMobile { get; set; }
        public int Discount { get; set; }

        public virtual Class Class { get; set; }
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}

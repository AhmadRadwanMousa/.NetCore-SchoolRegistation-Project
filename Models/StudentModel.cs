using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegistration.Models
{
    public class StudentModel
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int StudentAge { get; set; }
        public int ClassID { get; set; }
        public string ClassNumber { get; set; }
        public string MedicalIssues { get; set; }
        public string FatherMobile { get; set; }
        public int Discount { get; set; }
        public List<CustomSubjects> SubjectList { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }

    }
    public class CustomSubjects {

        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsChecked { get; set; }
    }
}

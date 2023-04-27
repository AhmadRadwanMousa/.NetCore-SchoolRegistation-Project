using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolRegistration.Entity
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Qualification { get; set; }
        public int CatagoryId { get; set; }
        public int Salary { get; set; }
        public DateTime JoinDate { get; set; }
    }
}

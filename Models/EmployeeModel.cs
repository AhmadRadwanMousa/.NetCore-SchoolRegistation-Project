using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegistration.Models
{
    public class EmployeeModel
    {
        public int EmployeeID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "You cant leave it empty ")]
        public string  FirstName{ get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "You cant leave it empty ")]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "You cant leave it empty ")]
        public string Qualification { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "You cant leave it empty ")]
        public int Age { get; set; }
        [Required( ErrorMessage = "You cant leave it empty ")]
        public int CatagoryID { get; set; }
        public string CatagoryName { get; set; }
        public int Salary { get; set; }
        public DateTime JoinDate{ get; set; }
    }
}

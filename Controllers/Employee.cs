using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegistration.Controllers
{
    public class Employee : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddNewEmployee()
        {
            Entity.SchoolRegistrationSystemContext context = new Entity.SchoolRegistrationSystemContext();
            var Data = context.Catagories.ToList();
            ViewBag.Category = Data;
            return View();
        }
        public IActionResult AddEmployee(Models.EmployeeModel Emp)
        {
            Entity.SchoolRegistrationSystemContext context = new Entity.SchoolRegistrationSystemContext();
            Entity.Employee EmpData = new Entity.Employee();
            EmpData.FirstName = Emp.FirstName;
            EmpData.LastName = Emp.LastName;
            EmpData.Age = Emp.Age;
            EmpData.PhoneNumber = Emp.PhoneNumber;
            EmpData.Qualification = Emp.Qualification;
            EmpData.Salary = Emp.Salary;
            EmpData.CatagoryId = Emp.CatagoryID;
            EmpData.JoinDate = Emp.JoinDate.Date;
          
            context.Employees.Add(EmpData);
            context.SaveChanges();
            return RedirectToAction("AddNewEmployee");

        }
        public IActionResult GetAllEmployee()
        {
            Entity.SchoolRegistrationSystemContext context = new Entity.SchoolRegistrationSystemContext();
            List<Models.EmployeeModel> EmpsInfo = new List<Models.EmployeeModel>();

            
            EmpsInfo =(from emp in context.Employees.ToList() 
                      join cat in context.Catagories.ToList() on emp.CatagoryId equals cat.CatagoryId
             select new Models.EmployeeModel
             {
                 EmployeeID=emp.EmployeeId,
                 FirstName = emp.FirstName,
                 PhoneNumber= emp.PhoneNumber,
                 LastName = emp.LastName,
                 Age=emp.Age,
                 Qualification =emp.Qualification,
                CatagoryName =cat.CatagoryName,
                JoinDate =emp.JoinDate ,
                Salary =emp.Salary,
                 
             }
                 ).ToList();
          
            return View(EmpsInfo);
        }
        public IActionResult Delete(int ID)
        {
            Entity.SchoolRegistrationSystemContext context = new Entity.SchoolRegistrationSystemContext();
            Entity.Employee obj = new Entity.Employee();
            obj= context.Employees.ToList().Where(x => x.EmployeeId ==ID).FirstOrDefault();
            context.Employees.Remove(obj);
            context.SaveChanges();
            return RedirectToAction("GetAllEmployee");

        }

        public ActionResult Update(Models.EmployeeModel Emp)
        {
            Entity.SchoolRegistrationSystemContext context = new Entity.SchoolRegistrationSystemContext();
            var result = context.Employees.Where(x => x.EmployeeId == Emp.EmployeeID).FirstOrDefault();
            result.FirstName = Emp.FirstName;
            result.LastName= Emp.LastName;
            result.Age = Emp.Age;
            result.PhoneNumber = Emp.PhoneNumber;
            result.Qualification= Emp.Qualification;
            result.CatagoryId = Emp.CatagoryID;
            result.Salary = Emp.Salary;
            result.JoinDate = Emp.JoinDate;
            context.SaveChanges();
            return RedirectToAction("GetAllEmployee");
        }
        public ActionResult UpdateEmp(int ID )
        {
            Entity.SchoolRegistrationSystemContext context = new Entity.SchoolRegistrationSystemContext();
            var result = (from emps in context.Employees.Where(x => x.EmployeeId == ID)
                          select new Models.EmployeeModel
                          {
                              EmployeeID=emps.EmployeeId,
                              FirstName=emps.FirstName,
                              LastName=emps.LastName,
                              Age=emps.Age,
                              Qualification=emps.Qualification,
                              PhoneNumber=emps.PhoneNumber,
                              CatagoryID=emps.CatagoryId,
                              JoinDate=emps.JoinDate,
                              Salary=emps.Salary,

                          }).FirstOrDefault();
            var CategoryList = context.Catagories.ToList();
            ViewBag.Category = CategoryList;
               
            return View (result);

        }


    }
}

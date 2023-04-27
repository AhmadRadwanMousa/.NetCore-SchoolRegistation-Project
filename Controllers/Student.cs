using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegistration.Controllers
{
    public class Student : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login ()
        {
            return View();
        }
        public IActionResult LoginForm(Models.Login input)
        {
            if (input.Username == "AhmadZuiod" && input.Password == "AhmadZuiod2")
            {
                return RedirectToAction("GetAllStudent");
            }
            else
            {
                return RedirectToAction("Login");

            }
         
        }
        public IActionResult AddStudent(Models.StudentModel model)
        {
            Entity.SchoolRegistrationSystemContext context = new Entity.SchoolRegistrationSystemContext();
            Entity.Student std = new Entity.Student();
            std.StudentName = model.StudentName;
            std.StudentAge=model.StudentAge;
            std.FatherMobile = model.FatherMobile;
            std.MedicalIssues = model.MedicalIssues;
            std.ClassId = model.ClassID;
            std.Discount = model.Discount;
            context.Students.Add(std);
            context.SaveChanges();
            Entity.StudentSubject SB= new Entity.StudentSubject();
            SB.StudentId = std.StudentId;
            SB.SubjectId = model.SubjectId;
            context.StudentSubjects.Add(SB);
            context.SaveChanges();

            return RedirectToAction ("AddNewStudent");
           
        }
        public IActionResult AddNewStudent() {
            Entity.SchoolRegistrationSystemContext context = new Entity.SchoolRegistrationSystemContext();

            var ClassData = context.Classes.ToList();
            ViewBag.Data= ClassData;
            Models.StudentModel Subject = new Models.StudentModel();
            Subject.SubjectList = new List< Models.CustomSubjects>();
            Subject.SubjectList =(from x in context.Subjects.ToList()
             select new Models.CustomSubjects
             {
                 ID = x.SubjectId,
                 Name = x.SubjectName,
                 IsChecked = false,

             }).ToList();
            return View(Subject);
        }
        public IActionResult GetAllStudent()
        {
            Entity.SchoolRegistrationSystemContext context = new Entity.SchoolRegistrationSystemContext();
            var subject = (from sub in context.Subjects.ToList()
                           join subStu in context.StudentSubjects.ToList() on sub.SubjectId equals subStu.SubjectId
                           select new {
                               StudentID = subStu.StudentId,
                               SubjectName = sub.SubjectName,
                           }).ToList();

           List <Models.StudentModel> model =new List<Models.StudentModel>();
          model =(from student in context.Students.ToList()
                        
                          select new Models.StudentModel
                          {
                              StudentID = student.StudentId,
                              StudentName = student.StudentName,
                              StudentAge = student.StudentAge,
                               MedicalIssues =student.MedicalIssues,
                              FatherMobile = student.FatherMobile,
                              Discount = student.Discount,
                              SubjectName = subject.Where(x => x.StudentID == student.StudentId).Select(x=> x.SubjectName).FirstOrDefault(),
                          }).ToList();
                

            return View(model);
        }
        public IActionResult UpdateStudent(int ID )
        {
            Entity.SchoolRegistrationSystemContext context = new Entity.SchoolRegistrationSystemContext();
            Models.StudentModel model = new Models.StudentModel();
             model = (from std in context.Students.Where(x => x.StudentId == ID)
                          select new Models.StudentModel
                          {
                              StudentID =std.StudentId,
                              StudentName = std.StudentName,
                              StudentAge = std.StudentAge,
                              FatherMobile = std.FatherMobile,
                              Discount=std.Discount,
                              ClassID = std.ClassId,
                              MedicalIssues = std.MedicalIssues,
                          }


             ).FirstOrDefault();
            var Stdsub = context.StudentSubjects.ToList();
           model.SubjectList = (from x in context.Subjects.ToList()
                                  select new Models.CustomSubjects 
                                  { 
                                  ID=x.SubjectId,
                                  Name =x.SubjectName,
                                      IsChecked =(Stdsub.Where(y => y.StudentId == ID && y.SubjectId == x.SubjectId).Count()> 0) ? true : false,
                                  }).ToList ();
            var ClassData = context.Classes.ToList();
            ViewBag.Data = ClassData;

            return View(model);
        }
        public IActionResult EditStudent(Models.StudentModel model ) {
            Entity.SchoolRegistrationSystemContext context = new Entity.SchoolRegistrationSystemContext();
            Entity.Student std = new Entity.Student();
            std = context.Students.Where(x => x.StudentId == model.StudentID).FirstOrDefault();
            std.StudentName = model.StudentName;
            std.StudentId = model.StudentID;
            std.StudentAge = model.StudentAge;
            std.ClassId = model.ClassID;
            std.FatherMobile = model.FatherMobile;
            std.Discount = model.Discount;
            std.MedicalIssues = model.MedicalIssues;
            context.SaveChanges();
            List<Entity.StudentSubject> list = context.StudentSubjects.Where(x => x.StudentId == model.StudentID).ToList();
            foreach (Entity.StudentSubject item in list)
            {
                context.StudentSubjects.Remove(item);
            }
            Entity.StudentSubject SB = new Entity.StudentSubject();
            SB.StudentId = std.StudentId;
            SB.SubjectId = model.SubjectId;
            context.StudentSubjects.Add(SB);
            context.SaveChanges();
           
         
       

            return RedirectToAction ("GetAllStudent");
        }
        public IActionResult Delete(int ID)
        {

            Entity.SchoolRegistrationSystemContext context = new Entity.SchoolRegistrationSystemContext();
            Entity.Student std = new Entity.Student();
         

            List<Entity.StudentSubject> list = context.StudentSubjects.Where(x => x.StudentId == ID).ToList();
            foreach (Entity.StudentSubject item in list)
            {
                context.StudentSubjects.Remove(item);
            }
            context.SaveChanges();
            std = context.Students.Where(x => x.StudentId == ID).FirstOrDefault();
          

            context.Students.Remove(std);
            context.SaveChanges();
            return RedirectToAction("GetAllStudent");
        }
    }
}

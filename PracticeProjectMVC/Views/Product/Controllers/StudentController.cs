using System;
using PracticeProjectMVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeProjectMVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAllStudents()
        {
            StudentContext abc = new StudentContext();
            List<Student> list = abc.StudentList.ToList();
            return View(list);
        }
        public ActionResult GetStudentById(int? id)
        {
            if (id == null || id < 1)
            {
                return null;
            }
            StudentContext context = new StudentContext();

            Student objStudent = context.StudentList.ToList().Find(std => std.StudentId == id);

            return View(objStudent);
        }
        public ActionResult GetStudentByName(string name)
        {
            if (name == null || name.Length < 1)
            {
                return null;
            }
            StudentContext context = new StudentContext();

            Student objStudent = context.StudentList.ToList().Find(std => std.StudentName.Contains(name));

            return View(objStudent);


        }

        public ActionResult GetDBStudent()
        {
            CommonManager cm = new CommonManager();
           //Product objProduct = cm.DBOperation();
            return View();
        }
        public ActionResult GetDBProduct(int id)
        {
            CommonManager cm = new CommonManager();
            Product objProduct = cm.DBOperation(id);
            return View(objProduct);
        }
    }
    }


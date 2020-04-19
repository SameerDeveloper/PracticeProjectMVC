using System;
using PracticeProjectMVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace PracticeProjectMVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetProductById(int productid)
        {
            CommonManager cm = new CommonManager();
            Product objProduct = cm.GetDBProduct(productid);
            return View(objProduct);
        }
        public ActionResult GetAllStudent()
        {
            CommonManager cm = new CommonManager();
            List<Product> list = cm.GetAllStudent();
            return View(list);
        }
    }
}


//public ActionResult GetAllStudents()
//{
//    StudentContext ctx = new StudentContext();
//    List<Student> list = ctx.StudentList.ToList();
//    return View(list);
//}
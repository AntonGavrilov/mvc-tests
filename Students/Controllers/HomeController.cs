using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Students.Models;


namespace Students.Controllers
{
    public class HomeController : Controller
    {
        private StudentsContext db = new StudentsContext();

        public ActionResult Index()
        {
            string controller = RouteData.Values["controller"].ToString();

            return View(db.Students.ToList());
        }
        

        [HttpGet]
        public ActionResult Edit(int id = 0, string studentStr = "")
        {

            if (!string.IsNullOrWhiteSpace(studentStr))
            {
                return Content(studentStr + " " + id.ToString());
            }
            
             
            Student student = db.Students.Find(id);

            if(student == null)
            {
                return HttpNotFound();
            }

            ViewBag.Courses = db.Courses.ToList();
            ViewBag.StudentsCount = db.Students.Count();


            return View(student);
        }

        [HttpGet]
        public ActionResult Array()
        {
            return View("test привет");
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(db.Students.ToList());
        }
    
        [HttpPost]
        public ActionResult Add(List<Student> students)
        {
            Student curStudent;

            foreach (var student in students)
            {
                curStudent = db.Students.Find(student);

                if (curStudent == null)
                {
                    return HttpNotFound("Не найдена книга по ID " + student.Id);
                }

                db.Entry(curStudent).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return View("Index");
        }


        [HttpGet]
        public ActionResult Add2()
        {
            Student firstStudent = db.Students.First();
            
            return View(firstStudent);
        }

        [HttpPost]
        public string Add2(Student student, Student myStudent)
        {

            return "sd";
        }
        [HttpPost]
        public string Array(List<string> names)
        {
            string fin = "";

            for (int i = 0; i < names.Count; i++)
            {
                fin += names[i] + "; ";
            }
            foreach (var item in HttpContext.Request.Headers.Keys)
            {
                fin+= item + "; ";
            } 
            return fin;
        }

        [HttpPost]
        public ActionResult Edit(Student student, int[] selectedCourses)
        {
            Student curStudent = db.Students.Find(student.Id);
            curStudent.Name = student.Name;
            curStudent.Surename = student.Surename;
            curStudent.Courses.Clear();

            if(selectedCourses != null)
            {
                foreach (var c in db.Courses.Where(co => selectedCourses.Contains(co.Id)))
                {
                    curStudent.Courses.Add(c);
                }
            }

            db.Entry(curStudent).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");

        }


        public ActionResult Details(int? id)
        {
            Student student = db.Students.Find(id);

            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
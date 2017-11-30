using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Students.Models
{
    public class CourseDbIntitializer : DropCreateDatabaseAlways<StudentsContext>
    {

        protected override void Seed(StudentsContext context)
        {
            Student s1 = new Student { Id = 0, Name = "Егор", Surename = "Иванова" };
            Student s2 = new Student { Id = 1, Name = "Мария", Surename = "Васильева" };
            Student s3 = new Student { Id = 2, Name = "Олег", Surename = "Кузнецов" };
            Student s4 = new Student { Id = 3, Name = "Ольга", Surename = "Петрова" };

            context.Students.Add(s1);
            context.Students.Add(s2);
            context.Students.Add(s3);
            context.Students.Add(s4);


            Course c1 = new Course
            {
                Id = 1,
                Name = "Операционные системы",
                Students = new List<Student>() { s1, s2, s3 }
            };

            Course c2 = new Course
            {
                Id = 1,
                Name = "Алгоритмы и структуры данных",
                Students = new List<Student>() { s2, s4 }
            };

            Course c3 = new Course
            {
                Id = 1,
                Name = "Основы HTML и CSS",
                Students = new List<Student>() { s3, s4, s1 }
            };


            context.Courses.Add(c1);
            context.Courses.Add(c2);
            context.Courses.Add(c3);

            base.Seed(context);

        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Models
{
    public class Student
    {        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surename { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        
        public Student()
        {
            
            Courses = new List<Course>();
        }
    }
}
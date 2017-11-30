using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace Students.Models
{
    public class Course
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Student> Students { get; set; }

        public Course()
        {
            Students = new List<Student>();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc.Models
{
    public class Visitor
    {
        public int id { get; set; }
        public string Login { get; set; }
        public string Ip { get; set; }
        public string Url { get; set; }
        public DateTime Date { get; set; }
    }

}
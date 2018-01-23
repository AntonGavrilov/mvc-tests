using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace mvc.Models
{
    public class LogContext : DbContext
    {
        public DbSet<Visitor> Visitors { get; set; }
    }
}
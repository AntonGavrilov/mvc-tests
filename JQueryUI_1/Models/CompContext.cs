using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace JQueryUI_1.Models
{
    public class CompContext : DbContext
    {
        public CompContext()
            :base("DefaultConnection")
        {

        }
        public DbSet<Computer> Computers { get; set; }
    }
}
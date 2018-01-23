using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Data.
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplicationIdentityCustom.Models
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base("IdentityDb")
        { }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
    }

    public class ApplicationUser: IdentityUser
    {
        public int Year { get; set; }

        public ApplicationUser()
        {

        }

    }


}